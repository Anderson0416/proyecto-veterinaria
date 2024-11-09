using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Cita_Tipo_Consulta
    {
        Cita_Tipo_Consulta_Repositorio cita_tipo_consulta_repositorio = new Cita_Tipo_Consulta_Repositorio();
        public void Guardar_Cita_Consultas(List<Tipo_Consulta> tipos_consultas)
        {
            Cita_Repositorio cita_repositorio = new Cita_Repositorio();
            int cita_id = cita_repositorio.Ultima_Cita_Registrada();

            foreach (var tipo_consulta in tipos_consultas)
            {
                Cita_Tipo_Consulta citaTipoConsulta = new Cita_Tipo_Consulta
                {
                    citas = new Citas { id = cita_id },
                    tipo_consulta = new Tipo_Consulta { id = tipo_consulta.id }
                };
                cita_tipo_consulta_repositorio.Registrar_Cita_Tipo_Consulta(citaTipoConsulta);
            }
        }
        public List<Cita_Tipo_Consulta> Cita_Tipo_Consulta_Ultima()
        { 
            Cita_Repositorio cita_repositorio = new Cita_Repositorio();
            int ultima_cita = cita_repositorio.Ultima_Cita_Registrada();
            List<Cita_Tipo_Consulta> citas_tipos_consultas = cita_tipo_consulta_repositorio.Consultar_Todas_Cita_Tipo_Consulta();
            var resultado = citas_tipos_consultas
                .Where(cc => cc.citas.id == ultima_cita)
                .ToList();
            return resultado;
        }
        public List<Cita_Tipo_Consulta> Citas_Tipo_Consultas_Id(int id)
        {
            List<Cita_Tipo_Consulta> Citas_Consultas = cita_tipo_consulta_repositorio.Consultar_Todas_Cita_Tipo_Consulta();
            List<Cita_Tipo_Consulta> citas_Filtradas = Citas_Consultas.Where(cc => cc.citas.id == id).ToList();
            return citas_Filtradas;
        }
        public string Eliminar_Citas(int id)
        {
            cita_tipo_consulta_repositorio.Eliminar_Cita_Tipo_Consulta(id);
            return "LA CITA FUE ELIMINADA EXITOSAMENTE";
        }
    }
}