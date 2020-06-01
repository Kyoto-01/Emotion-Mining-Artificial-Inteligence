using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestEmotionMining
{
    public class Think
    {
        string cst;

        public Think(string connectionStringFromDbMemoryes)
        {
            this.cst = connectionStringFromDbMemoryes;
        }

        public string BuscarSentimento(List<string> tokens, List<int> qtdTokens)
        {
            double positivo = 0, negativo = 0;

            for (int i = 0; i < tokens.Count; i++)
            {
                positivo += BuscarProbabilidadeSentimento(tokens[i], "qtdPositiva") * qtdTokens[i];
                negativo += BuscarProbabilidadeSentimento(tokens[i], "qtdNegativa") * qtdTokens[i];
            }
            return CompararSentimentos(positivo, negativo);
        }

        private string CompararSentimentos(double positivo, double negativo)
        {
            if (positivo > negativo)
            {
                return "positivo";
            }
            else if (negativo > positivo)
            {
                return "negativo";
            }
            return "neutro";
        }

        private double BuscarProbabilidadeSentimento(string token, string sentimentoProbColumnName)
        {
            string select = string.Format("SELECT {0} FROM tb_memory WHERE token=@tk", sentimentoProbColumnName);

            using (SqlConnection con = new SqlConnection(cst))
            {
                using (SqlCommand cmd = new SqlCommand(select, con))
                {
                    con.Open();

                    cmd.Parameters.Add("tk", System.Data.SqlDbType.NVarChar).Value = token;
                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
        }
    }
}
