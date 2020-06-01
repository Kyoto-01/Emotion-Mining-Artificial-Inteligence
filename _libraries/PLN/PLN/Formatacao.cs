using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLN
{
    public class Formatacao
    {
        public List<string> Formatacao_completa(string documento)
        {
            List<string> tokens;

            documento = documento.ToLower();
            documento = Retirar_pontuacao(documento);
            documento = Retirar_acentos(documento);
            tokens = documento.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            tokens = TrimTokensList(tokens);
            return Retirar_stop_words(tokens);
        }

        public List<string> TrimTokensList(List<string> tokens)
        {
            List<string> tokensTrim = new List<string>();

            foreach (string tk in tokens)
            {
                tokensTrim.Add(tk.Trim());
            }
            return tokensTrim;
        }

        public string Retirar_pontuacao(string documento)
        {
            char[] sinaisDePontuacao = { ',', '.', ';', '?', '!', '"', '”', '“', '\'', ':', '(', ')',
                                         ' ', '-', '_', ']', '[', '{', '}', '…'};
            foreach (char sinal in sinaisDePontuacao)
            {
                documento = documento.Replace(sinal, ' ');
            }
            return documento;
        }

        public string Retirar_acentos(string documento)
        {
            char[] acentos = { 'à', 'á', 'â', 'ã', 'è', 'é', 'ê', 'ì', 'í',
                                'î', 'ò', 'ó', 'ô', 'õ', 'ù', 'ú', 'û', 'ñ', 'ç' };
            char[] letras = { 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'i', 'i', 
                              'i', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'n', 'c' };

            for (int i = 0; i < acentos.Length; i++)
            {
                documento = documento.Replace(acentos[i], letras[i]);
            }
            return documento;
        }

        public List<string> Retirar_stop_words(List<string> tokens)
        {
            string diretorio = System.IO.Directory.GetCurrentDirectory() + "/stopwords.txt";
            List<string> tokensWithoutStopwords = new List<string>();

           // if (System.IO.Directory.Exists(diretorio))
            {
                string[] stopwords = System.IO.File.ReadAllLines(diretorio, Encoding.Default);

                foreach (string token in tokens)
                {
                    if (!stopwords.Contains(token))
                    {
                        tokensWithoutStopwords.Add(token);
                    }
                }
                return tokensWithoutStopwords;
            }
            /*else
            {
                System.Windows.Forms.MessageBox.Show("Está faltando um arquivo importante, isso" +
                " fará com que as stopwords de seu texto não sejam eliminadas. Crie uma lista de stopwords denominada " +
                "\"stopwords.txt\" no diretorio de seu executável.", "PNL.dll: falta de arquivo", 
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

                return tokens;
            }*/
        }

        public List<string> Retirar_itens_repetidos(IEnumerable<string> lista)
        {
            return lista.Distinct().ToList();
        }

        public List<string> CopyList(List<string> lista)
        {
            string[] tks = new string[lista.Count];
            lista.CopyTo(tks);
            return tks.ToList();
        }
    }
}
