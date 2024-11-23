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

using LiveCharts;
using LiveCharts.Wpf;

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : UserControl
    {
        private List<Factura> facturas;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Meses { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Facturas()
        {
            InitializeComponent();
            Llenar_Combobox();
            Llenar_DataGrid();
            Graficos();
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
            if (dtp_Filtrar_Fecha.SelectedDate is DateTime fechaSeleccionada)
            {
                var facturasFiltradas = facturas
                    .Where(f => f.fecha.Date == fechaSeleccionada.Date)
                    .ToList();
                dtg_Tabla_Compra.ItemsSource = facturasFiltradas;
            }
            else
            {
                dtg_Tabla_Compra.ItemsSource = facturas;
            }
        }
        private void dtg_Tabla_Compra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var facturaSeleccionada = dtg_Tabla_Compra.SelectedItem as Factura;

            if (facturaSeleccionada != null)
            {
                int id_Factura = facturaSeleccionada.id;
                Detalle_Factura detalleFactura = new Detalle_Factura(id_Factura);
                detalleFactura.Show();
            }
        }
        private void Graficos ()
        {
            var totalesPorMes = facturas
                .GroupBy(f => f.fecha.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    Total = g.Sum(f => f.total)
                })
                .OrderBy(x => x.Mes)
                .ToList();
            string[] nombresMeses = new string[]
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Total Ganado",
                    Values = new ChartValues<double>(totalesPorMes.Select(x => (double)x.Total))
                }
            };
            Meses = totalesPorMes.Select(x => nombresMeses[x.Mes - 1]).ToArray();
            Formatter = value => value.ToString("C");
            DataContext = this;
        }
    }
}
