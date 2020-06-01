using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace TrainingEmotionMining
{
    public class treino
    {
        string cst;
        string[] sentimentoList = { "qtdPositiva", "qtdNegativa" };

        public treino(string connectionString)
        {
            cst = connectionString;
        }

        public void Memorizar(List<string> tokensList, List<int> qtdTokens, byte sentimento)
        {
            using (SqlConnection con = new SqlConnection(cst))
            {
                string select = "SELECT * FROM tb_memory;";
                using (SqlCommand cmd = new SqlCommand(select, con))
                {
                    con.Open();
                    List<string> memoriasNovas = ReturnNewMemoryes(cmd, tokensList, qtdTokens, sentimento);
                    InsertNewMemoryes(con, memoriasNovas, qtdTokens, sentimento);

                    NaiveBayes nb = new NaiveBayes();
                    nb.SetProbabilidades(tokensList, cst);
                }
            }
        }

        private List<string> ReturnNewMemoryes(SqlCommand cmd, List<string> tokens, List<int> qtdTokens,
                                            byte sentimento)
        {
            List<string> tokensCopy = new PLN.Formatacao().CopyList(tokens);
            int tokensNovos = 0;

            //para verificar se a memoria já existe, se sim, atualiza e remove
            // da lista de novas memorias:
            for (int i = 0; i < tokens.Count; i++)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (tokens[i] == reader["token"].ToString())
                    {
                        int readerQtdSentimento = (int)reader[sentimentoList[sentimento]];
                        reader.Dispose();
                        UpdateMemoryes(cmd.Connection, tokens[i], qtdTokens[i], readerQtdSentimento, sentimento);
                        tokensCopy.Remove(tokens[i]);
                        goto proximoToken;
                    }
                }
                tokensNovos++;
            proximoToken:
                reader.Dispose();
            }
            return tokensCopy;
        }

        private void UpdateMemoryes(SqlConnection con, string token, int qtdToken, int qtdSentimento, byte sentimento)
        {
            string update = "UPDATE tb_memory SET " + sentimentoList[sentimento] + "=@qtd WHERE token=@tk;";
            qtdSentimento += qtdToken;

            using (SqlCommand cmd = new SqlCommand(update, con))
            {
                cmd.CommandText = update;
                cmd.Parameters.Add("qtd", System.Data.SqlDbType.Int).Value = qtdSentimento;
                cmd.Parameters.Add("tk", System.Data.SqlDbType.NVarChar, 100).Value = token;
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertNewMemoryes(SqlConnection con, List<string> tokens, List<int> qtdTokens, byte sentimento)
        {
            string command = "INSERT INTO tb_memory([token], [qtdPositiva], [qtdNegativa]) " +
                             "VALUES (@tk, @qtdp, @qtdn);";

            for (int i = 0; i < tokens.Count; i++)
            {
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.Add("tk", System.Data.SqlDbType.NVarChar, 100).Value = tokens[i];
                    cmd.Parameters.Add("qtdp", System.Data.SqlDbType.Int).Value = qtdTokens[i];
                    cmd.Parameters.Add("qtdn", System.Data.SqlDbType.Int).Value = 0;

                    if (sentimento == 0)
                    {
                        cmd.Parameters["qtdp"].Value = qtdTokens[i];
                        cmd.Parameters["qtdn"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["qtdp"].Value = 0;
                        cmd.Parameters["qtdn"].Value = qtdTokens[i];
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
