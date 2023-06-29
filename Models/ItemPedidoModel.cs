using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Game.Models
{
    public class ItemPedido
    {
        
        public int id { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
        public decimal preco_unitario { get; set; }
        public int id_pedido { get; set; }

    }
}