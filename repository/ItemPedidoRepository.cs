using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Game.Models
{
    class IItemPedidoRepository
    {
        public void Inserir(string Produto, int Quantidade, decimal Preco_unitario, int Id_pedido)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "INSERT INTO tb_itempedido (produto, quantidade, preco_unitario, id_pedido) " +
                               "VALUES (@Produto, @Quantidade, @Preco_unitario, @Id_pedido)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Produto", Produto);
                    command.Parameters.AddWithValue("@Quantidade", Quantidade);
                    command.Parameters.AddWithValue("@Preco_unitario", Preco_unitario);
                    command.Parameters.AddWithValue("@Id_pedido", Id_pedido);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Item inserido com sucesso!");
            Console.WriteLine();
        }

        public void Ler()
        {
            Console.WriteLine("------ Itens no pedido ------");

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT * FROM tb_itempedido";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = int.Parse(reader["Id"].ToString());
                            string Produto = reader["Produto"].ToString();
                            int Quantidade = int.Parse(reader["Quantidade"].ToString());
                            decimal Preco_unitario = decimal.Parse(reader["Preco_unitario"].ToString());
                            int Id_pedido = int.Parse(reader["Id_pedido"].ToString());


                            Console.WriteLine($"Id: {Id} | Produto: {Produto} | Quantidade: {Quantidade} | Preco_unitario: {Preco_unitario} | Do_pedido: {Id_pedido} ");
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
                string query = "DELETE FROM tb_itempedido WHERE id = @Id";
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Linhas afetadas: " + rowsAffected);

                }
            }
        }


        public void Atualizar(int Id, string Produto, int Quantidade, decimal Preco_unitario, int Id_pedido)
        {

            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "UPDATE tb_itempedido SET produto = @Produto, quantidade = @Quantidade, preco_unitario = @Preco_unitario, id_pedido = Id_pedido WHERE id = @Id";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", Id); // Valor do ID que deseja atualizar
                    command.Parameters.AddWithValue("@Produto", Produto); // Novo valor para o campo Nome
                    command.Parameters.AddWithValue("@Quantidade", Quantidade); // Novo valor para o campo Data
                    command.Parameters.AddWithValue("@Preco_unitario", Preco_unitario); // Novo valor para o campo Status
                    command.Parameters.AddWithValue("@Id_Pedido", Id_pedido); // Valor do ID que deseja atualizar

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Linhas afetadas: " + rowsAffected);

                }
            }
        }

        public void SomarValor(int Id_pedido)
        {
            using (MySqlConnection connection = new MySqlConnection(projeto.Program.connectionString))
            {
                string query = "SELECT SUM(quantidade * preco_unitario) AS total FROM tb_itempedido WHERE id_pedido = @Id_pedido";
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id_pedido", Id_pedido);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal total = Convert.ToDecimal(result);
                        Console.WriteLine("Valor total: " + total);
                    }

                }
            }

        }




    }
}
