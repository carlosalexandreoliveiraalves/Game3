
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Game.Models
{
    class IPedidoRepository
    {

        public void Inserir(string NomeCliente, DateTime DataPedido, string Status)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "INSERT INTO tb_pedido (NomeCliente, DataPedido, Status) " +
                               "VALUES (@NomeCliente, @DataPedido, @Status)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeCliente", NomeCliente);
                    command.Parameters.AddWithValue("@DataPedido", DataPedido);
                    command.Parameters.AddWithValue("@Status", Status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Pedido realizado com sucesso!");
            Console.WriteLine();
        }

        public void Ler()
        {
            Console.WriteLine("------ Pedidos ------");

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT * FROM tb_pedido";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = int.Parse(reader["Id"].ToString());
                            string NomeCliente = reader["NomeCliente"].ToString();
                            DateTime DataPedido = DateTime.Parse(reader["DataPedido"].ToString());
                            string Status = reader["Status"].ToString();

                            Console.WriteLine($"Pedido: {Id} | NomeCliente: {NomeCliente} | DataPedido: {DataPedido} | Status: {Status}");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        public void Excluir(int Id)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "DELETE FROM tb_pedido WHERE id = @Id";
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Linhas afetadas: " + rowsAffected);

                }
            }
        }

        public void Atualizar(int Id, string NomeCliente, DateTime DataPedido, string Status)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "UPDATE tb_pedido SET NomeCliente = @NomeCliente, DataPedido = @DataPedido, Status = @Status  WHERE id = @Id";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@NomeCliente", NomeCliente); // Novo valor para o campo Nome
                    command.Parameters.AddWithValue("@DataPedido", DataPedido); // Novo valor para o campo Data
                    command.Parameters.AddWithValue("@Status", Status); // Novo valor para o campo Status
                    command.Parameters.AddWithValue("@Id", Id); // Valor do ID que deseja atualizar

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Linhas afetadas: " + rowsAffected);

                }
            }
        }


        public void LerNome(string? NomeCliente)
        {
            Console.WriteLine("------ Pedidos ------");

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT * FROM tb_pedido WHERE NomeCliente = @NomeCliente";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeCliente", NomeCliente);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = int.Parse(reader["Id"].ToString());
                            string NomeDoCliente = reader["NomeCliente"].ToString();
                            DateTime DataPedido = DateTime.Parse(reader["DataPedido"].ToString());
                            string Status = reader["Status"].ToString();

                            Console.WriteLine($"Pedido: {Id} | NomeCliente: {NomeDoCliente} | DataPedido: {DataPedido} | Status: {Status}");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        public void LerData(DateTime DataPedido)
        {
            Console.WriteLine("------ Pedidos ------");

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT * FROM tb_pedido WHERE DataPedido = @DataPedido";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataPedido", DataPedido);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = int.Parse(reader["Id"].ToString());
                            string NomeCliente = reader["NomeCliente"].ToString();
                            DateTime DataDoPedido = DateTime.Parse(reader["DataPedido"].ToString());
                            string Status = reader["Status"].ToString();

                            Console.WriteLine($"Pedido: {Id} | NomeCliente: {NomeCliente} | DataPedido: {DataDoPedido} | Status: {Status}");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        public void LerStatus(string Status)
        {
            Console.WriteLine("------ Pedidos ------");

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT * FROM tb_pedido WHERE Status = @Status";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", Status);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = int.Parse(reader["Id"].ToString());
                            string NomeCliente = reader["NomeCliente"].ToString();
                            DateTime DataPedido = DateTime.Parse(reader["DataPedido"].ToString());
                            string StatusPedido = reader["Status"].ToString();

                            Console.WriteLine($"Pedido: {Id} | NomeCliente: {NomeCliente} | DataPedido: {DataPedido} | Status: {StatusPedido}");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

    }
}
