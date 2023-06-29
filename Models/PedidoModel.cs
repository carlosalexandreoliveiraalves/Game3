using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Game.Models
{
    public class Pedido
    {
        
        public int id { get; set; }
        public string nomeCliente { get; set; }
        public DateTime dataPedido { get; set; }
        public string status { get; set; }


    }
}