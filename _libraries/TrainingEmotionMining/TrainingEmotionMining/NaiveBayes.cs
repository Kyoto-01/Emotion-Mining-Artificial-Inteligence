using System.Collections.Generic;
using System.Data.SqlClient;

namespace TrainingEmotionMining
{
    internal class NaiveBayes
    {
        double totalGeral = 0, totalPositive = 0, totalNegative = 0;
        double totalPositiveToken = 0, totalNegativeToken = 0;
        double bayesPositivo = 0, bayesNegativo = 0;
       
        public void SetProbabilidades(List<string> tokens, string connectionString)
        {
            List<double> probabilidadesPositivo = new List<double>();
            List<double> probabilidadesNegativo = new List<double>();

            foreach (string tk in tokens)
            {
                totalGeral = 0;
                totalPositive = 0;
                totalNegative = 0;

                BuscarDadosToken(tk, connectionString);

                if (totalPositive == 0 && totalNegative > 0)
                {
                    bayesNegativo = 1;
                }
                else if (totalNegative == 0 && totalPositive > 0)
                {
                    bayesPositivo = 1;
                }
                else if (totalPositive > 0 && totalNegative > 0)
                {
                    CalcularNaiveBayes();
                }

                probabilidadesPositivo.Add(bayesPositivo);
                probabilidadesNegativo.Add(bayesNegativo);
            }
            SalvarProbabilidades(tokens, probabilidadesPositivo, probabilidadesNegativo, connectionString);
        }

        private void CalcularNaiveBayes()
        {
            double probPositivo = totalPositive / totalGeral;
            double probNegativo = totalNegative / totalGeral;

            double probAcertarTalQuePositivo = totalPositiveToken / totalPositive;
            double probAcertarTalQueNegativo = totalNegativeToken / totalNegative;

            double probAcertarEPositivo = probPositivo * probAcertarTalQuePositivo;
            double probAcertarENegativo = probNegativo * probAcertarTalQueNegativo;

            double probTotal = probAcertarEPositivo + probAcertarENegativo;
            bayesPositivo = probAcertarEPositivo / probTotal;
            bayesNegativo = probAcertarENegativo / probTotal;
        }

        private void BuscarDadosToken(string token, string connectionString)
        {
            string select = string.Format("SELECT token, qtdPositiva, qtdNegativa FROM tb_memory;");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(select, con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        totalPositive += reader.GetInt32(1);
                        totalNegative += reader.GetInt32(2);
                        totalGeral += reader.GetInt32(1) + reader.GetInt32(2);

                        if (reader["token"].ToString() == token)
                        {
                            totalPositiveToken = reader.GetInt32(1);
                            totalNegativeToken = reader.GetInt32(2);
                        }
                    }
                }
            }
        }

        private void SalvarProbabilidades(List<string> tokens, List<double> probsPos, List<double> probsNeg, string connectionString)
        {
            string update = string.Format("UPDATE tb_memory SET probPositiva=@pos, probNegativa=@neg WHERE token=@tk;");
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    con.Open();

                    cmd.Parameters.Add("tk", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("pos", System.Data.SqlDbType.Float);
                    cmd.Parameters.Add("neg", System.Data.SqlDbType.Float);

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        cmd.Parameters["tk"].Value = tokens[i];
                        cmd.Parameters["pos"].Value = probsPos[i];
                        cmd.Parameters["neg"].Value = probsNeg[i];

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
