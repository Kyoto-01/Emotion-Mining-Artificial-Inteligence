using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineradorDeEmocoes
{
    class Mineracao
    {
        string connectionString = "";

        public Mineracao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string MinerarEmocoes(string texto)
        {
            string document = texto.Trim();
            PLN.Formatacao formatac = new PLN.Formatacao();
            PLN.Stemming stemm = new PLN.Stemming();
            PLN.DataMining dataMining = new PLN.DataMining();

            List<string> tokens = formatac.Formatacao_completa(document);
            tokens = stemm.StemmizarListaDeTokens(tokens);
            List<int> qtdRepeticoesToken = dataMining.Calcular_frequencia_tokens(tokens);
            tokens = formatac.Retirar_itens_repetidos(tokens);

            return DetectarEmocao(tokens, qtdRepeticoesToken);
        }

        private string DetectarEmocao(List<string> tokens, List<int> qtdRepeticaoTokens)
        {
            TestEmotionMining.Think pensamento = new TestEmotionMining.Think(connectionString);
            return pensamento.BuscarSentimento(tokens, qtdRepeticaoTokens);
        }
    }
}
