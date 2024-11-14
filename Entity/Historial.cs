using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Historial
    {
        public int id { get; set; }

        public DateTime fecha { get; set; }
        public Mascota mascota { get; set; }
        public Anamnesis anamnesis { get; set; }
    }
}
