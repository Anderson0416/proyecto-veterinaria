using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Veterinario
    {
        Veterinario_Repositorio veterinario_repositorio = new Veterinario_Repositorio();
        public string Guardar_Veterinario(Veterinario veterinario)
        {
            string respuesta = Validar_Campos(veterinario);
            if (respuesta != null)
            {
                return respuesta;
            }

            respuesta = Validar_existencia(veterinario);
            if (respuesta != null)
            {
                return respuesta;
            }
            veterinario_repositorio.Registrar_Veterinario(veterinario);
            return "VETERINARIO FUE GUARDADO EXITOSAMENTE";
        }
        private string Validar_Campos(Veterinario veterinario)
        {
            if (string.IsNullOrEmpty(veterinario.documento) || string.IsNullOrEmpty(veterinario.apellido) ||
                string.IsNullOrEmpty(veterinario.tipo_documento) || string.IsNullOrEmpty(veterinario.sexo) ||
                string.IsNullOrEmpty(veterinario.nombre) || string.IsNullOrEmpty(veterinario.telefono) ||
                veterinario.Fecha_nacimiento == default(DateTime) || veterinario.fecha_contrato == default(DateTime))
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_existencia(Veterinario veterinario)
        {
            if (veterinario_repositorio.Existencia_Veterinario(veterinario.documento))
            {
                return "EL VETERINARIO YA EXISTE";
            }
            return null;
        }
        public List<Veterinario> Lista_Todos_Veterinario()
        {
            List<Veterinario> veterinarios = new List<Veterinario>();
            veterinarios = veterinario_repositorio.ObtenerVeterinarios();
            return veterinarios;
        }
    }
}
