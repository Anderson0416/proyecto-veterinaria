using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string tipo_documento { get; set; }
        public string sexo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string telefono { get; set; }
    }
}
