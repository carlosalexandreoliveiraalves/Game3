using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Game.Models;


//static string connectionString = "server=localhost;port=3306;database=db_hospital;uid=root;password=;";

namespace projeto
{
    class Program
    {
        public static string connectionString = "server=localhost;port=3306;database=db_game;uid=root;password=root;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("------ Sistema de pedidos ------");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Cadastrar pedido.");
                Console.WriteLine("2. Cadastrar item no pedido.");
                Console.WriteLine("------ \\ ------");
                Console.WriteLine("3. Visualizar pedidos.");
                Console.WriteLine("4. Visualizar itens nos pedidos.");
                Console.WriteLine("------ \\ ------");
                Console.WriteLine("5. Deletar pedido.");
                Console.WriteLine("6. Deletar item no pedido.");
                Console.WriteLine("------ \\ ------");
                Console.WriteLine("7. Atualizar pedido.");
                Console.WriteLine("8. Atualizar item no pedido.");
                Console.WriteLine("------ \\ ------");
                Console.WriteLine("9. Ver pedido por nome.");
                Console.WriteLine("10. Ver pedido por data.");
                Console.WriteLine("11. Ver pedido por status.");
                Console.WriteLine("------ \\ ------");
                Console.WriteLine("12. Valor total do pedido.");
                Console.WriteLine("0. Sair");
                Console.WriteLine();

                Console.Write("Opção selecionada: ");
                int opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    case 1:
                        Game.Models.ProgramPedido.pedido();
                        break;
                    case 2:
                        Game.Models.ProgramItemPedido.ItemPedido();
                        break;
                    case 3:
                        Game.Models.IPedidoRepository pedidoRepository = new Game.Models.IPedidoRepository();
                        pedidoRepository.Ler();
                        break;
                    case 4:
                        Game.Models.IItemPedidoRepository itempedidoRepository = new Game.Models.IItemPedidoRepository();
                        itempedidoRepository.Ler();
                        break;
                    case 5:
                        Game.Models.ProgramPedido.ExcluirPedido();
                        break;
                    case 6:
                        Game.Models.ProgramItemPedido.ExcluirItemPedido();
                        break;
                    case 7:
                        Game.Models.ProgramPedido.AtualizarPedido();
                        break;
                    case 8:
                        Game.Models.ProgramItemPedido.AtualizarItemPedido();
                        break;
                    case 9:
                        Game.Models.ProgramPedido.LerNomePedido();
                        break;
                    case 10:
                        Game.Models.ProgramPedido.LerDataPedido();
                        break;
                    case 11:
                        Game.Models.ProgramPedido.LerStatusPedido();
                        break;

                    case 12:
                        Game.Models.ProgramPedido.ValorTotalPedido();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }

}