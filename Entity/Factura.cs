using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public Propietario propietario { get; set; }
        public decimal total { get; set; }
    }
}
