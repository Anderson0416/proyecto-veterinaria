using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Mascota
    {
        Mascota_Repositorio mascota_repositorio = new Mascota_Repositorio();

        public string Guardar_Mascota(Mascota mascota)
        {
            string respuesta = Validar_Campos(mascota);
            if (respuesta != null)
            {
                return respuesta;
            }

            respuesta = Validar_existencia_Propietario(mascota);
            if (respuesta != null)
            {
                return respuesta;
            }
            mascota_repositorio.Registrar_Mascota(mascota);
            return "LA MASCOTA FUE GUARDADA EXITOSAMENTE";
        }
        private string Validar_Campos(Mascota mascota)
        {
            if (string.IsNullOrEmpty(mascota.nombre) || string.IsNullOrEmpty(mascota.sexo) ||
                string.IsNullOrEmpty(mascota.especie) || string.IsNullOrEmpty(mascota.raza))
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_existencia_Propietario(Mascota mascota)
        {
            Propietario_Repositorio propietario_repositorio = new Propietario_Repositorio();   
            if (!propietario_repositorio.Existencia_Propietario(mascota.propietario.documento))
            {
                return "EL PROPIETARIO NO EXISTE";
            }
            return null;
        }
        public List<Mascota> Lista_Todos_Mascota()
        {
            List<Mascota> mascotas = new List<Mascota>();
            mascotas = mascota_repositorio.Consultar_Todos_Mascota();
            return mascotas;
        }
        public string Eliminar_Mascota(Mascota mascota)
        {
            mascota_repositorio.Eliminar_Mascota(mascota.id);
            return "LA MASCOTA FUE ELIMINADA EXITOSAMENTE";
        }
        public string Actualizar_Mascota(Mascota mascota)
        {
            string respuesta = Validar_Campos(mascota);
            if (respuesta != null)
            {
                return respuesta;
            }
            mascota_repositorio.Actualizar_Mascota(mascota);
            return "MASCOTA ACTUALIZADA EXITOSAMENTE";
        }
        public List<Mascota> Mascotas_Propietario(string documento)
        {
            List<Mascota> todasLasMascotas = Lista_Todos_Mascota();
            List<Mascota> mascotas_filtradas = todasLasMascotas
                .Where(m => m.propietario.documento == documento)
                .ToList();
            return mascotas_filtradas;
        }
        public Mascota Consultar_Mascota_Id(int id)
        {
            List<Mascota> todasLasMascotas = Lista_Todos_Mascota();
            Mascota mascota = todasLasMascotas
                .FirstOrDefault(m => m.id == id);
            return mascota;
        }
    }
}
