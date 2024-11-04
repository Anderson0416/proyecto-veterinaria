using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Seccion
    {
        public static string Nombre { get; set; }
        public static int Tipo_usuario { get; set; }
        public static int id { get; set; }
        public static Veterinario veterinario { get; set; }
        public static void AsignarVeterinario(Veterinario veterinarios)
        {
            veterinario = veterinarios;

        }
    }
}
