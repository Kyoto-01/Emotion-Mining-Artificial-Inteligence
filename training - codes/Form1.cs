using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PLN;
using TrainingEmotionMining;

namespace TreinoMineracaoDeEmocoes
{
    public partial class Form1 : Form
    {
        byte emocao;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_positive_Click(object sender, EventArgs e)
        {
            emocao = 0;

            btn_negative.Enabled = false;
            btn_negative.BackColor = Color.Gray;

            btn_treinar.Enabled = true;
            lbl_titulo.Select();
        }

        private void btn_negative_Click(object sender, EventArgs e)
        {
            emocao = 1;

            btn_positive.Enabled = false;
            btn_positive.BackColor = Color.Gray;

            btn_treinar.Enabled = true;
            lbl_titulo.Select();
        }

        private void btn_treinar_Click(object sender, EventArgs e)
        {
            Treinar();

            btn_positive.Enabled = true;
            btn_positive.BackColor = Color.GreenYellow;

            btn_negative.Enabled = true;
            btn_negative.BackColor = Color.Red;

            btn_treinar.Enabled = false;

            MessageBox.Show("Aprendi mais palavras, obrigado!");
            txt_texto.Text = "";
            lbl_titulo.Select();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_positive.Enabled = true;
            btn_positive.BackColor = Color.GreenYellow;

            btn_negative.Enabled = true;
            btn_negative.BackColor = Color.Red;

            btn_treinar.Enabled = false;
        }

        private void Treinar()
        {
            string cst = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + System.IO.Directory.GetCurrentDirectory() + "\\memorias\\test_memory.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
            string document = txt_texto.Text.Trim();

            Formatacao fmtc = new Formatacao();
            Stemming stmg = new Stemming();
            DataMining dm = new DataMining();

            List<string> tokensFormatados = fmtc.Formatacao_completa(document);
            List<string> tokensStemmizados = stmg.StemmizarListaDeTokens(tokensFormatados);
            List<int> qtdRepeticaoTokens = dm.Calcular_frequencia_tokens(tokensStemmizados);
            List<string> tokensRepetidosEliminados = fmtc.Retirar_itens_repetidos(tokensStemmizados);

            treino tr = new treino(cst);
            tr.Memorizar(tokensRepetidosEliminados, qtdRepeticaoTokens, emocao);
        } 
    }
}
