using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Detalle_Factura.xaml
    /// </summary>
    public partial class Detalle_Factura : Window
    {
        int id_Factura;
        public Detalle_Factura(int id)
        {
            InitializeComponent();
            id_Factura = id;
            Llenar_DataGrid();
        }

        private void Llenar_DataGrid()
        {
            Servicio_Detalle_Factura servicioDetalleFactura = new Servicio_Detalle_Factura();
            List<Detalles_Factura> detallesFiltrados = servicioDetalleFactura.Filtrar_Detalles_Factura(id_Factura);
         
            dtg_Tabla_Compra.ItemsSource = detallesFiltrados;
        }
    }
}
