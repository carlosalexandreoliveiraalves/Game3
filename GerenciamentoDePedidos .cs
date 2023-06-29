using System;
using Game.Models;

namespace Game.Models
{
    class ProgramPedido
    {

        public static void pedido()
        {
            Console.Clear();

            Console.Write("Digite o nome do cliente que fez o pedido: ");
            string? NomeCliente = Console.ReadLine();

            Console.WriteLine("Digite uma data no formato dd/MM/yyyy:");
            string? input = Console.ReadLine();

            DateTime parsedDateTime;

            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDateTime))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente:");
                input = Console.ReadLine();
            }

            Console.Write("Digite o status do pedido: ");
            string? Status = Console.ReadLine();

            IPedidoRepository pedidoRepository = new IPedidoRepository();
            pedidoRepository.Inserir(NomeCliente, parsedDateTime, Status);
        }

        public static void AtualizarPedido()
        {
            Console.Write("Digite o id do pedido: ");
            int Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo nome do cliente que fez o pedido: ");
            string? NomeCliente = Console.ReadLine();

            Console.WriteLine("Digite a nova data no formato dd/MM/yyyy:");
            string? input = Console.ReadLine();

            DateTime parsedDateTime;

            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDateTime))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente:");
                input = Console.ReadLine();
            }

            Console.Write("Digite o novo status do pedido: ");
            string? Status = Console.ReadLine();

            IPedidoRepository pedidoRepository = new IPedidoRepository();
            pedidoRepository.Atualizar(Id, NomeCliente, parsedDateTime, Status);
        }

        public static void ExcluirPedido()
        {
            Console.Write("Digite o id do pedido: ");
            int Id = int.Parse(Console.ReadLine());

            IPedidoRepository pedidoRepository = new IPedidoRepository();
            pedidoRepository.Excluir(Id);
        }


        public static void LerNomePedido()
        {
            Console.Write("Digite o nome do cliente: ");
            string? nome = Console.ReadLine();

            bool check = ValidarProgram.ValidarUsuario(nome);

            if (check == true)
            {
                Game.Models.IPedidoRepository pedidoRepository = new Game.Models.IPedidoRepository();
                pedidoRepository.LerNome(nome);
            }
            else
            {
                Console.WriteLine("Nome não existe!");
            }

        }


        public static void LerDataPedido()
        {
            Console.WriteLine("Digite a data: ");
            string? input = Console.ReadLine();

            DateTime parsedDateTime;

            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDateTime))
            {
                Console.WriteLine("Formato de data inválido. Digite novamente:");
                input = Console.ReadLine();
            }

            bool check = ValidarProgram.ValidarData(parsedDateTime);

            if (check == true)
            {
                Game.Models.IPedidoRepository pedidoRepository = new Game.Models.IPedidoRepository();
                pedidoRepository.LerData(parsedDateTime);
            }
            else
            {
                Console.WriteLine("Data não existe!");
            }

        }


        public static void LerStatusPedido()
        {
            Console.Write("Digite o status do pedido: ");
            string? status = Console.ReadLine();

            bool check = ValidarProgram.ValidarStatus(status);

            if (check == true)
            {
                Game.Models.IPedidoRepository pedidoRepository = new Game.Models.IPedidoRepository();
                pedidoRepository.LerStatus(status);
            }
            else
            {
                Console.WriteLine("Status não encontrado!");
            }

        }

        public static void ValorTotalPedido()
        {
            Console.Write("Digite o id do pedido você deseja ver o valor: ");
            int id = int.Parse(Console.ReadLine());

            IItemPedidoRepository itempedidoRepository = new IItemPedidoRepository();
            itempedidoRepository.SomarValor(id);

        }







    }

}