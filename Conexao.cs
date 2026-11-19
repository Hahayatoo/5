using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    public class Conexao
    {
        // Fabrica e devolve uma conexão já aberta com o banco DB_Delivery
        public MySqlConnection conectarBD()
        {
            MySqlConnection conn;

            string dadosConexao = "Persist Security Info = false; " +
                                  "server = localhost; " +
                                  "database = DB_Delivery; " +
                                  "uid = root; " +
                                  "pwd = ;";

            try
            {
                conn = new MySqlConnection(dadosConexao);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Conexão não estabelecida: " + ex.Message);
            }
        }
    }
}
