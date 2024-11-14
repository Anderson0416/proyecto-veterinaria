using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Anamnesis
    {
        public int id { get; set; }
        public int peso { get; set; }
        public string peso2 { get; set; }
        public string estado_reproductivo { get; set; }
        public string tipo_vivienda { get; set; }
        public string actividad_fisica { get; set; }
        public string vacunas_previas { get; set; }
        public string vacunas_precias_desparecitacion { get; set; }
        public string motivo_consulta { get; set; }
        public string sintomas_mascota { get; set; }
        public string observaciones { get; set; }
        public string dieta { get; set; }
        public Historial historal { get; set; }
    }
}
