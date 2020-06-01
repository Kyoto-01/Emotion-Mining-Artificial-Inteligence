using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLN
{
    public class Stemming
    {
        public List<string> StemmizarListaDeTokens(List<string> tokens)
        {
            string diretorio = System.IO.Directory.GetCurrentDirectory() + "/suffixList.txt";

            List<string> tokensStemmizados = new List<string>();

            //if (System.IO.Directory.Exists(diretorio))
            {
                List<string> sufixos = System.IO.File.ReadAllLines(diretorio, Encoding.Default).ToList();

                foreach (string tk in tokens)
                {
                    string r1 = GetRegion(tk);
                    string stemmToken = tk;

                    if (r1 != "")
                    {
                        stemmToken = SubstituirSufixo(tk, sufixos, r1);
                    }
                    tokensStemmizados.Add(stemmToken);
                }
                return tokensStemmizados;
            }
            /*else
            {
                System.Windows.Forms.MessageBox.Show("Está faltando um arquivo importante, isso" +
                " fará com que os seus tokens não sejam stemmizados. Crie uma lista de sufixos denominada " +
                "\"suffixList.txt\" no diretorio de seu executável.", "PNL.dll: falta de arquivo", 
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

                return tokens;
            }*/
        }

        private string GetRegion(string token)
        {
            // retorna uma região localizada após a primeira consoante
            // depois da primeira vogal de token
            string vogais = "aeiou";
            byte numeroVogal = 0;
            int index = 0;

            for (int i = 0; i < token.Length; i++)
            {
                foreach (char vogal in vogais)
                {
                    if (token[i] == vogal)
                    {
                        numeroVogal++;
                        break;
                    }       
                    if (numeroVogal >= 1)
                    {
                        index = i + 1;
                        goto fim;
                    }
                }
            }
        fim:
            if (index == 0 || index > token.Length)
            {
                return "";
            }
            return token.Substring(index);
        }
       
        private string SubstituirSufixo(string token, List<string> sufixos, string r1)
        {
            foreach (string suf in sufixos)
            {
                if (r1.Contains(suf) && r1.IndexOf(suf) == r1.Length - suf.Length)
                {
                    token = SubstituirR1(token, suf);
                    token = DeleteSuffixIPrecededByC(token);
                    return LimpezaFinalDeSufixos(token);
                }
            }
            token = LimpezaFinalDeSufixos(token);
            return RemoveResidualSuffix(token); ;
        }

        private string LimpezaFinalDeSufixos(string token)
        {
            if (token.EndsWith("e"))
            {
                token = token.Remove(token.Length - 1);
                if (token.EndsWith("gue") ||  token.EndsWith("cie"))
                {
                    token = token.Remove(token.Length - 2);
                }
            }
            return token;
        }

        private string RemoveResidualSuffix(string token)
        {
            List<string> residualSuffixes = new List<string>{"os", "a", "i", "o"};

            foreach (string sufix in residualSuffixes)
            {
                if (token.EndsWith(sufix))
                {
                    token = token.Remove(token.IndexOf(sufix, token.Length - sufix.Length));
                }
            }
            return token;
        }

        private string DeleteSuffixIPrecededByC(string token)
        {
            if (token.EndsWith("ci"))
            {
                token = token.Remove(token.Length - 1);
            }
            return token;
        }

        private string SubstituirR1(string token, string sufixo)
        {
            if (sufixo == "logia" || sufixo == "logias")
            {
                return token.Replace(sufixo, "log");
            }
            else if (sufixo == "ucion" || sufixo == "uciones")
            {
                return token.Replace(sufixo, "u");
            }
            else if (sufixo == "encia" || sufixo == "encias")
            {
                return token.Replace(sufixo, "ente");
            }
            else if (sufixo == "amente")
            {
                List<string> finais = new List<string>{"ivamente", "atamente", 
                            "osamente", "icamente", "adamente"};
                return VerificarOcorrenciasEspecificas(finais, token);
            }
            else if (sufixo == "mente")
            {
                List<string> finais = new List<string>{"antemente", "avelmente", "ivelmente"};
                return VerificarOcorrenciasEspecificas(finais, token);
            }
            else if (sufixo == "idade" || sufixo == "idades")
            {
                List<string> finais = new List<string>{"abilidade", "icidade",
                            "ividade", "abilidades", "icidades", "ividades"};
                return VerificarOcorrenciasEspecificas(finais, token);
            }
            else if (sufixo == "iva" || sufixo == "ivo" || sufixo == "ivas" ||
                     sufixo == "ivos")
            {
                List<string> finais = new List<string> { "ativa", "ativo", "ativas", "ativos" };
                return VerificarOcorrenciasEspecificas(finais, token);
            }
            else if (token.EndsWith("eira") || token.EndsWith("eiras"))
            {
                token = token.Replace("eiras", "ir");
                token = token.Replace("eira", "ir");
                return token;
            }
            return token.Remove(token.IndexOf(sufixo));
        }

        private string VerificarOcorrenciasEspecificas(List<string> finais, string token)
        {
            foreach (string final in finais)
            {
                if (token.EndsWith(final))
                {
                    return token.Remove(token.IndexOf(final));
                }
            }
            return token;
        }
    }
}
