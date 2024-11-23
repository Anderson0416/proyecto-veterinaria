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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : UserControl
    {
        private List<Factura> facturas;
        public Facturas()
        {
            InitializeComponent();
            Llenar_Combobox();
            Llenar_DataGrid();
        }
        private void Llenar_Combobox()
        {
            cmb_Filtro_mes.ItemsSource = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Where(m => !string.IsNullOrEmpty(m))
               .Select((m, index) => new { Nombre = m, Mes = index + 1 })
               .ToList();
            cmb_Filtro_mes.DisplayMemberPath = "Nombre";
            cmb_Filtro_mes.SelectedValuePath = "Mes";
        }
        private void Llenar_DataGrid()
        {
            Servicio_Factura servicio_Factura = new Servicio_Factura();
            facturas = servicio_Factura.Lista_Factura();
            dtg_Tabla_Compra.ItemsSource = facturas;
        }

        private void cmb_Filtro_mes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_Filtro_mes.SelectedValue is int mesSeleccionado)
            {
                var facturasFiltradas = facturas
                    .Where(f => f.fecha.Month == mesSeleccionado)
                    .ToList();
                dtg_Tabla_Compra.ItemsSource = facturasFiltradas;
            }
        }
        private void dtp_Filtrar_Fecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verificar que se haya seleccionado una fecha.
            if (dtp_Filtrar_Fecha.SelectedDate is DateTime fechaSeleccionada)
            {
                // Filtrar las facturas según la fecha seleccionada.
                var facturasFiltradas = facturas
                    .Where(f => f.fecha.Date == fechaSeleccionada.Date)
                    .ToList();

                // Mostrar los datos filtrados en el DataGrid.
                dtg_Tabla_Compra.ItemsSource = facturasFiltradas;
            }
            else
            {
                // Si no hay fecha seleccionada, mostrar todas las facturas.
                dtg_Tabla_Compra.ItemsSource = facturas;
            }
        }
        private void dtg_Tabla_Compra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
