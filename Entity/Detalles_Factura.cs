using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Detalles_Factura
    {
        public int id { get; set; }
        public Factura factura { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal sub_total { get; set; }
    }
}
