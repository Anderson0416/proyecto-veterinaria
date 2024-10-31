using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Propietario
    {
        Propietario_Repositorio propietario_repositorio = new Propietario_Repositorio();
        public string Guardar_Propietario(Propietario propietario)
        {
            string respuesta = Validar_Campos(propietario);
            if (respuesta != null)
            {
                return respuesta;
            }

            respuesta = Validar_existencia(propietario);
            if (respuesta != null)
            {
                return respuesta;
            }
            propietario_repositorio.Registrar_Propietario(propietario);
            return "PROPIETARIO FUE GUARDADO EXITOSAMENTE";
        }
        private string Validar_Campos(Propietario propietario)
        {
            if (string.IsNullOrEmpty(propietario.documento) || string.IsNullOrEmpty(propietario.apellido) ||
                string.IsNullOrEmpty(propietario.tipo_documento) || string.IsNullOrEmpty(propietario.documento) ||
                string.IsNullOrEmpty(propietario.nombre) || string.IsNullOrEmpty(propietario.telefono) || propietario.Fecha_nacimiento == default(DateTime))
                {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_existencia(Propietario propietario)
        {
            if (propietario_repositorio.Existencia_Propietario(propietario.documento))
            {
                return "EL CLIENTE YA EXISTE";
            }
            return null;
        }
        public List<Propietario> Lista_Todos_Propietarios()
        {
            List<Propietario> propietarios = new List<Propietario>();
            propietarios = propietario_repositorio.Consultar_Todos_Propietarios();
            return propietarios;
        }
        public string Eliminar_Proprietario(Propietario propietario)
        {
            propietario_repositorio.Eliminar_Propietario(propietario.documento);
            return "El PROPIETARIO FUE ELIMINADO EXITOSAMENTE";
        }
        public string Actualizar_Propietario(Propietario propietario)
        {
            string respuesta = Validar_Campos(propietario);
            if (respuesta != null)
            {
                return respuesta;
            }
            propietario_repositorio.Actualizar_Propietario(propietario);
            return "PROPIETARIO ACTUALIZADO EXITOSAMENTE";
        }
        public Propietario Consultar_Propietario_Documento(string documento)
        {
            List<Propietario> propietarios = propietario_repositorio.Consultar_Todos_Propietarios();
            Propietario propietario = propietarios.FirstOrDefault(p => p.documento == documento);
            return propietario;
        }
        
    }
}
