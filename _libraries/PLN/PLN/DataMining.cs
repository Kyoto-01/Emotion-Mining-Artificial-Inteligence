using System;
using System.Collections.Generic;

namespace PLN
{
    public class DataMining
    {
        public List<int> Calcular_frequencia_tokens(List<string> tokenList)
        {
            int tokensRepetidos = 0;
            List<string> tokensRepetidosList = new List<string>();
            List<int> qtdTokensRepetidos = new List<int>();

            for (int j = 0; j < tokenList.Count; j++)
            {
                if (!tokensRepetidosList.Contains(tokenList[j]))
                {
                    tokensRepetidosList.Add(tokenList[j]);
                    qtdTokensRepetidos.Add(0);

                    for (int i = 0; i < tokenList.Count; i++)
                    {
                        if (tokenList[j] == tokenList[i])
                        {
                            qtdTokensRepetidos[j - tokensRepetidos]++;
                        }
                    }
                    continue;
                }
                tokensRepetidos++;
            }
            return qtdTokensRepetidos;
        }
    }
}
