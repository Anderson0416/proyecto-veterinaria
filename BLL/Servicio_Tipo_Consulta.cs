using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Tipo_Consulta
    {
        Tipo_Consulta_Repositorio tipo_consulta_repositorio = new Tipo_Consulta_Repositorio();
        public string Guardar_Tipo_Consulta(Tipo_Consulta tipo_Consulta)
        {
            string respuesta = Validar_Campos(tipo_Consulta);
            if (respuesta != null)
            {
                return respuesta;
            }

            respuesta = Validar_existencia(tipo_Consulta);
            if (respuesta != null)
            {
                return respuesta;
            }
            tipo_consulta_repositorio.Registrar_Tipo_Consulta(tipo_Consulta);
            return "EL TIPO DE CONSULTA FUE GUARDADO EXITOSAMENTE";
        }
        private string Validar_Campos(Tipo_Consulta tipo_Consulta)
        {
            if (string.IsNullOrEmpty(tipo_Consulta.nombre) || string.IsNullOrEmpty(tipo_Consulta.descripcion) ||
                tipo_Consulta.precio < 0)
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_existencia(Tipo_Consulta tipo_Consulta)
        {
            if (tipo_consulta_repositorio.Existecia_Tipo_Consulta(tipo_Consulta.nombre))
            {
                return "EL TIPO DE CONSULTA YA EXISTE";
            }
            return null;
        }
        public List<Tipo_Consulta> Lista_Tipo_Consulta()
        {
            List<Tipo_Consulta> tipo_Consultas = new List<Tipo_Consulta>();
            tipo_Consultas = tipo_consulta_repositorio.Obtener_Tipo_Consulta();
            return tipo_Consultas;
        }
        public string Eliminar_Tipo_Consulta(Tipo_Consulta tipo_Consulta)
        {
            tipo_consulta_repositorio.Eliminar_Tipo_Consulta(tipo_Consulta.id);
            return "EL TIPO DE CONSULTA FUE ELIMINADO EXITOSAMENTE";
        }
        public string Actualizar_Tipo_Consulta(Tipo_Consulta tipo_Consulta)
        {
            string respuesta = Validar_Campos(tipo_Consulta);
            if (respuesta != null)
            {
                return respuesta;
            }
            tipo_consulta_repositorio.Actualizar_Tipo_Consulta(tipo_Consulta);
            return "EL TIPO DE CONSULTA FUE ACTUALIZADO EXITOSAMENTE";
        }
    }
}
