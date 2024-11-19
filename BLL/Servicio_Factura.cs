using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Factura
    {
        public int Registrar_Factura(Factura factura)
        {
            Factura_Repositorio factura_repositorio = new Factura_Repositorio();
            int id_factura = factura_repositorio.Registrar_Factura(factura);
            return id_factura;
        }
        public List<Factura> Lista_Factura()
        {
            Factura_Repositorio factura_repositorio = new Factura_Repositorio();
            List<Factura> facturas = new List<Factura>();
            facturas = factura_repositorio.Obtener_Facturas();
            return facturas;
        }
    }
}
