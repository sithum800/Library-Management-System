
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public class DatabaseConnection
    {
        private string connectionString = "Server=localhost;Port=3306;Database=library_management_system;Uid=root;Pwd=admin;";
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
} 