using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Historial
    {
        public int Registrar_Historial(Historial historial)
        {
            Historial_Repositorio historial_repositorio = new Historial_Repositorio();
            return historial_repositorio.Registrar_Historial(historial);
        }
        public List<Historial> Lista_Historial()
        {
            Historial_Repositorio historial_repositorio = new Historial_Repositorio();
            List<Historial> historiales = historial_repositorio.Consultar_Historiales();
            return historiales;
        }
    }
}
