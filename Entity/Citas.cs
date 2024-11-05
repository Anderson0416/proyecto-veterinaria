using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Citas
    {
        public int id { get; set; }
        public DateTime fecha_cita { get; set; }
        public string estado { get; set; }
        public decimal total_pagar { get; set; }
        public string nota { get; set; }
        public Propietario propietario { get; set; }
        public Mascota mascota { get; set; }
        public Veterinario veterinario { get; set; }
    }
}
