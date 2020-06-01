using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineradorDeEmocoes
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + System.IO.Directory.GetCurrentDirectory() + "\\memorias\\test_memory.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";                 

        public Form1()
        {
            InitializeComponent();
        }

        private void Detectar_Click(object sender, EventArgs e)
        {
            string emocao = new Mineracao(connectionString).MinerarEmocoes(txt_texto.Text);

            txt_message.Text = "O sentimento contido no seu texto é: " + emocao.ToUpper();
            SetPictuteBoxEmotion(emocao);

            ConfirmarDeteccao();
        }

        private void SetPictuteBoxEmotion(string emocao)
        {
            if (emocao == "positivo")
            {
                pic_carinha.Image = Properties.Resources.positivo;
                return;
            }
            else if (emocao == "negativo")
            {
                pic_carinha.Image = Properties.Resources.negativo;
                return;
            }
            pic_carinha.Image = Properties.Resources.neutro;
        }

        private void ConfirmarDeteccao()
        {
            if (DialogResult.Yes != MessageBox.Show("Acertei?", "confirmação da resposta",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                MessageBox.Show("Então me ensine que sentimento expressa a sua frase, por favor!", "pedido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\treino.exe");
                return;
            }
            MessageBox.Show("Isso! Sabia que acertaria!");
        }
    }
}
