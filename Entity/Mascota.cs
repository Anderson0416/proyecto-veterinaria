using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Mascota
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public string sexo { get; set; }
        public string edad { get; set; }
        public string edad2 { get; set; }
        public Propietario propietario { get; set; }
    }
}
