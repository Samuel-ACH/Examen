using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public string Cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ISV { get; set; }
        public decimal Total { get; set; }

        public Pedidos()
        {
        }

        public Pedidos(int id, string identidadCliente, string cliente, decimal subTotal, decimal iSV, decimal total)
        {
            Id = id;
            IdentidadCliente = identidadCliente;
            Cliente = cliente;
            SubTotal = subTotal;
            ISV = iSV;
            Total = total;
        }
    }
}
