using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Cita
    {
        Cita_Repositorio cita_repositorio = new Cita_Repositorio();
        public string Registrar_Cita(Citas citas)
        {
            string respuesta = Validar_Campos(citas);
            if (!string.IsNullOrEmpty(respuesta))
            {
                return respuesta;
            }
            int resultado = cita_repositorio.Registrar_Cita(citas);
            return "LA CITA SE GUARDO EXITOSAMENTE";
        }
        public string Validar_Campos(Citas citas)
        {
            if (citas.fecha_cita == default || string.IsNullOrEmpty(citas.estado) ||
                citas.propietario.id <= 0 || citas.mascota.id <= 0 || citas.veterinario.id <= 0)
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        public List<Citas> Lista_Todos_Citas()
        {
            List<Citas> lista_citas = new List<Citas>();
            lista_citas = cita_repositorio.Consultar_Todas_Citas();
            return lista_citas;
        }
        public string Eliminar_Citas(Citas citas)
        {
            cita_repositorio.Eliminar_Cita(citas.id);
            return "LA CITA FUE ELIMINADA EXITOSAMENTE";
        }
        public string Actualizar_Citas(Citas citas)
        {
            cita_repositorio.Actualizar_Cita(citas);
            return "LA CITA FUE ACTUALIZADA EXITOSAMENTE";
        }
        public int Ultima_Cita_Registrada()
        {
            int cita_id = cita_repositorio.Ultima_Cita_Registrada();
            return cita_id;
        }
        public Citas Cita_Id(int id)
        {
            List<Citas> listaCitas = cita_repositorio.Consultar_Todas_Citas();
            Citas cita_Filtrada = listaCitas.FirstOrDefault(c => c.id == id);
            return cita_Filtrada;
        }
    }
}
