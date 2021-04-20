using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace RegistroAtividadesApp.Database
{
    class Conexao
    {
        private static string host = "localhost";

        private static string port = "3308";

        private static string user = "root";

        private static string password = "rootroot";

        private static string dbname = "db_atividades";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        private static MySqlDataAdapter adapter;

        private static DataTable dataTable;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection(this.Dns());
                connection.Open();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return command;
        }

        public void Close()
        {
            connection.Close();
        }

        private string Dns()
        {
            return $"server={host};user={user};database={dbname};port={port};password={password}";
        }

    }
}
