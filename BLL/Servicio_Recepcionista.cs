using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Recepcionista
    {
        Recepcionista_Repositorio recepcionista_repositorio = new Recepcionista_Repositorio();
        public string Guardar_Recepcionista(Recepcionista recepcionista)
        {
            string respuesta = Validar_Campos(recepcionista);
            if (respuesta != null)
            {
                return respuesta;
            }

            respuesta = Validar_existencia(recepcionista);
            if (respuesta != null)
            {
                return respuesta;
            }
            recepcionista_repositorio.Registrar_Recepcionista(recepcionista);
            return "RECEPCIONISTA FUE GUARDADO EXITOSAMENTE";
        }
        private string Validar_Campos(Recepcionista recepcionista)
        {
            if (string.IsNullOrEmpty(recepcionista.documento) || string.IsNullOrEmpty(recepcionista.apellido) ||
                string.IsNullOrEmpty(recepcionista.tipo_documento) || string.IsNullOrEmpty(recepcionista.sexo) ||
                string.IsNullOrEmpty(recepcionista.nombre) || string.IsNullOrEmpty(recepcionista.telefono) ||
                recepcionista.Fecha_nacimiento == default(DateTime) || recepcionista.fecha_contrato == default(DateTime))
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_existencia(Recepcionista recepcionista)
        {
            if (recepcionista_repositorio.Existencia_Recepcionista(recepcionista.documento))
            {
                return "EL RECEPCIONISTA YA EXISTE";
            }
            return null;
        }
    }
}
