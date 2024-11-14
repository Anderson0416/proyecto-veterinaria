using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Anamnesis
    {
        public string Guardar_Anamnesis(Anamnesis anamnesis)
        {
            Anamnesis_Repositorio anamnesis_repositorio = new Anamnesis_Repositorio();
            

            if (string.IsNullOrEmpty(anamnesis.vacunas_previas) || anamnesis.peso < 0 ||
                string.IsNullOrEmpty(anamnesis.sintomas_mascota))
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            else
            {
                anamnesis_repositorio.Registrar_Anamnesis(anamnesis);
            }
            return "EXITOSA";
        }
        public List<Anamnesis> Lista_Anamnesis()
        {
            Anamnesis_Repositorio anamnesis_repositorio = new Anamnesis_Repositorio();
            List<Anamnesis> anamneses = anamnesis_repositorio.Consultar_Anamnesis();
            return anamneses;
        }
        public Anamnesis Obtener_Anamnesis_Id(int id)
        {
            List<Anamnesis> anamnesisList = Lista_Anamnesis();
            Anamnesis anamnesis = anamnesisList.FirstOrDefault(a => a.id == id);

            return anamnesis;
        }
    }
}
