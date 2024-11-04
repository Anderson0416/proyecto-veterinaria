using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Veterinario : Persona
    {
        public DateTime fecha_contrato { get; set; }
        public Usuarios usuario { get; set; }
    }
}
