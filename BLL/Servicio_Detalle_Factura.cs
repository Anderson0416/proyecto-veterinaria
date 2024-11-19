using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Detalle_Factura
    {
        public void Registrar_Detalle_Factura(Detalles_Factura detalles_factura)
        {
            Detalle_Factura_Repositorio detalle_factura_repositorio = new Detalle_Factura_Repositorio();
            detalle_factura_repositorio.Registrar_Detalle_Factura(detalles_factura);
        }
        public List<Detalles_Factura> Lista_Factura()
        {
            Detalle_Factura_Repositorio detalle_factura_repositorio = new Detalle_Factura_Repositorio();
            List<Detalles_Factura> detalles_facturas = new List<Detalles_Factura>();
            detalles_facturas = detalle_factura_repositorio.Obtener_Detalle_Facturas();
            return detalles_facturas;
        }
    }
}
