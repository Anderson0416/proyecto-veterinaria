using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cita_Tipo_Consulta
    {
        public int id { get; set; }
        public Citas citas { get; set; }
        public Tipo_Consulta tipo_consulta { get; set; }
    }
}
