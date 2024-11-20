using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public List<Citas> Lista_Citas_Veterinario(int id)
        {
            List<Citas> citas = cita_repositorio.Consultar_Todas_Citas();
            var citas_Filtradas = citas.Where(c => c.veterinario.id == id).ToList();
            return citas_Filtradas;
        }
        public string Eliminar_Citas(Citas citas)
        {   
            if (citas != null)
            {
                cita_repositorio.Eliminar_Cita(citas.id);
                return "LA CITA FUE ELIMINADA EXITOSAMENTE";
            }
            else
            {
                return "No se ha seleccionado una cita para eliminar.";
            }
        }
        public string Actualizar_Citas(Citas citas)
        {
            cita_repositorio.Actualizar_Cita(citas);
            return "LA CITA FUE ACTUALIZADA EXITOSAMENTE";
        }
        public string Actualizar_Estado_Cita(int id, string estado)
        {
            cita_repositorio.Actualizar_Estado_Cita(id, estado);
            return "EL PAGO FUE EXITOSO";
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
        public List<Citas> Citas_Fecha()
        {
            List<Citas> Lista_Citas = new List<Citas> ();
            Lista_Citas = Lista_Todos_Citas();
            DateTime fecha = DateTime.Now;
            DateTime fecha_siguiente = fecha.AddDays(1);
            var citas_filtro = Lista_Citas.Where(c => c.fecha_cita.Date == fecha_siguiente.Date).ToList();
            return citas_filtro;
        }
    }
}
