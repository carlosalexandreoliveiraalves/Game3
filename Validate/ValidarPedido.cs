
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Game.Models
{
    class ValidarProgram
    {

        private static bool VerificarNome(string? NomeCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT COUNT(*) FROM tb_pedido WHERE NomeCliente = @NomeCliente";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeCliente", NomeCliente);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                    {                        
                        return true;
                    }
                    else
                    {                        
                        return false;
                    }

                }
            }

        }
        public static bool ValidarUsuario(string? nomeUsuario)
        {
            return VerificarNome(nomeUsuario);
        }



        private static bool VerificarData(DateTime DataPedido)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT COUNT(*) FROM tb_pedido WHERE DataPedido = @DataPedido";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataPedido", DataPedido);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }


        }
        public static bool ValidarData(DateTime DataPedido)
        {
            return VerificarData(DataPedido);
        }




        private static bool VerificarStatus(string? Status)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT COUNT(*) FROM tb_pedido WHERE Status = @Status";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", Status);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                    {                        
                        return true;
                    }
                    else
                    {                        
                        return false;
                    }

                }
            }


        }
        public static bool ValidarStatus(string? Status)
        {
            return VerificarStatus(Status);
        }

    }

}

