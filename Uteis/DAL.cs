using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaVendas.Uteis
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string DataBase = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={DataBase};Uid={User};Pwd={Password};Sslmode=none;";
        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();

        }
 
        /*ESSE METODO RECEBE UMA STRING COMO COMANDO EM SQL PARA SELECT*/
        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand Comand = new MySqlCommand(sql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(Comand);

            da.Fill(data);
            return data;
        }

        /*ESPERA UM PARAMETRO DO TIPO STRING
         CONTENDO UM COMANDO SQL DO TIPO INSERT, UPDATE, DELETE*/
        public void ExecutarComandoSql(string sql)
        {
            MySqlCommand Comand = new MySqlCommand(sql, Connection);
            Comand.ExecuteNonQuery();
        }

    }

}

