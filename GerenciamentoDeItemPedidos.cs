using System;
using Game.Models;

namespace Game.Models
{
    class ProgramItemPedido
    {

        public static void ItemPedido()
        {
            Console.Clear();

            Console.WriteLine("------ Inserir item no pedido ------");

            Console.Write("Digite o nome do produto: ");
            string? Produto = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            int Quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço do produto: ");
            decimal Preco_unitario = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o ID do pedido que vai este item: ");
            int id_pedido = int.Parse(Console.ReadLine());

            IItemPedidoRepository itempedidoRepository = new IItemPedidoRepository();
            itempedidoRepository.Inserir(Produto, Quantidade, Preco_unitario, id_pedido);
        }

        public static void AtualizarItemPedido()
        {

            Console.Write("Digite o Id do item que deseja mudar: ");
            int Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo nome do produto: ");
            string? Produto = Console.ReadLine();

            Console.Write("Digite a nova quantidade: ");
            int Quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo preço do produto: ");
            decimal Preco_unitario = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o novo ID do pedido que vai este item: ");
            int id_pedido = int.Parse(Console.ReadLine());

            IItemPedidoRepository itempedidoRepository = new IItemPedidoRepository();
            itempedidoRepository.Atualizar(Id, Produto, Quantidade, Preco_unitario, id_pedido);
        }

        public static void ExcluirItemPedido()
        {
            Console.Write("Digite o id do item no pedido: ");
            int Id = int.Parse(Console.ReadLine());

            IItemPedidoRepository itempedidoRepository = new IItemPedidoRepository();
            itempedidoRepository.Excluir(Id);
        }



    }

}