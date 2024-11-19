using BLL;
using Entity;
using iTextSharp.tool.xml.html;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Veterinaria_.Views
{
    /// <summary>
    /// Lógica de interacción para Compra.xaml
    /// </summary>
    public partial class Compra : UserControl
    {
        Servicio_Producto servicio_producto;
        private ObservableCollection<Producto> lista_Tipos_Productos;
        private ObservableCollection<Detalles_Factura> lista_Tipos_Compra = new ObservableCollection<Detalles_Factura>();
        private ICollectionView filtrar_datagrid;
        private ICollectionView filtrar_datagrid_Compra;
        int id_producto;
        int stock;
        int id_factura;
        public Compra()
        {
            servicio_producto = new Servicio_Producto();
            InitializeComponent();
            Llenar_DataGrid_Producto();
        }


        private void dtg_Tabla_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionar_valor_Producto();
        }

        private void dtg_Tabla_Compra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private Producto Consultar_Producto()
        {
            Producto producto = new Producto();
            producto = servicio_producto.Consultar_Producto(id_producto);
            return producto;
        }
        private void txt_Buscar_Producto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar_Producto.Text.ToLower();

            filtrar_datagrid.Filter = item =>
            {
                if (item is Producto producto)
                {
                    return producto.nombre.ToLower().Contains(filtro) ||
                           producto.descripcion.ToLower().Contains(filtro) ||
                           producto.precio.ToString().ToLower().Contains(filtro) ||
                           producto.stock.ToString().ToLower().Contains(filtro.ToLower());
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
        private void Llenar_DataGrid_Producto()
        {
            Servicio_Producto servicio_producto = new Servicio_Producto();
            lista_Tipos_Productos = new ObservableCollection<Producto>(servicio_producto.Lista_Productos());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_Tipos_Productos);
            dtg_Tabla_Producto.ItemsSource = filtrar_datagrid;
        }
        public void seleccionar_valor_Producto()
        {
            var Producto_Seleccionado = dtg_Tabla_Producto.SelectedItem as Producto;

            if (Producto_Seleccionado != null)
            {
                id_producto = int.Parse(Producto_Seleccionado.id.ToString());
                stock = int.Parse (Producto_Seleccionado.stock.ToString());
                txt_Nombre.Text = Producto_Seleccionado.nombre;
            }
        }
        public decimal Cacular_sud_Total()
        {
            Producto producto = new Producto();
            producto = Consultar_Producto();
            decimal cantidad = decimal.Parse(txt_Cantidad.Text);
            return producto.precio * cantidad;

        }
        private Detalles_Factura Datos_Factura()
        {
            Detalles_Factura detalle_factura = new Detalles_Factura();
            detalle_factura.cantidad = int.Parse(txt_Cantidad.Text);
            detalle_factura.sub_total = Cacular_sud_Total();
            detalle_factura.producto = new Producto();
            detalle_factura.producto.id = id_producto;
            detalle_factura.producto.nombre = txt_Nombre.Text;
            detalle_factura.producto.stock = stock;
            return detalle_factura;
        }
        private List<Detalles_Factura> Lista_Detalles_Facturas()
        {
            List<Detalles_Factura> lista_detalles_facturas = new List<Detalles_Factura>();
            Detalles_Factura detalles_Factura = new Detalles_Factura();
            detalles_Factura = Datos_Factura();
            lista_detalles_facturas.Add(detalles_Factura);
            return lista_detalles_facturas;
        }
        public void Llenar_DataGrid_Compra(Detalles_Factura detalle_factura)
        {
            Servicio_Producto servicio_Producto = new Servicio_Producto();
            if (detalle_factura.cantidad > detalle_factura.producto.stock)
            {
                MessageBox.Show($"El producto '{detalle_factura.producto.nombre}' tiene un stock insuficiente. Stock actual: {detalle_factura.producto.stock}", "Stock insuficiente", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            servicio_Producto.Restar_Stock(detalle_factura.producto, detalle_factura.cantidad);
            lista_Tipos_Compra.Add(detalle_factura);
            filtrar_datagrid_Compra = CollectionViewSource.GetDefaultView(lista_Tipos_Compra);
            dtg_Tabla_Compra.ItemsSource = filtrar_datagrid_Compra;
            Calcular_Total();
            Llenar_DataGrid_Producto();
        }
        private void Calcular_Total()
        {
            if (lista_Tipos_Compra != null && lista_Tipos_Compra.Any())
            {
                decimal total = lista_Tipos_Compra.Sum(detalle => detalle.sub_total);
                txt_Total.Text = total.ToString("F2");
            }
            else
            {
                txt_Total.Text = "0.00";
            }
        }
        private void Guardar_Datos_Factura()
        {
            Servicio_Factura servicio_factura = new Servicio_Factura();
            Factura factura = new Factura();
            factura.total = decimal.Parse(txt_Total.Text);
            id_factura = servicio_factura.Registrar_Factura(factura);
        }
        private void Guardar_Datos_Detalle_Factura()
        {
            if (lista_Tipos_Compra == null || !lista_Tipos_Compra.Any())
            {
                MessageBox.Show("No hay detalles de factura para guardar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Servicio_Detalle_Factura servicio_Detalle_Factura = new Servicio_Detalle_Factura();
            foreach (var detalle in lista_Tipos_Compra)
            {
                detalle.factura = new Factura { id = id_factura }; 
                servicio_Detalle_Factura.Registrar_Detalle_Factura(detalle);
            }
            MessageBox.Show("Los detalles de la factura se han registrado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            Detalles_Factura detalle_factura = Datos_Factura();

            // Llama a la función para añadir el detalle
            Llenar_DataGrid_Compra(detalle_factura);
        }

        private void txt_Buscar_Compra_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar_Compra.Text.ToLower();

            filtrar_datagrid_Compra.Filter = item =>
            {
                if (item is Detalles_Factura detalles_Factura)
                {
                    return detalles_Factura.producto.nombre.ToLower().Contains(filtro) ||
                           detalles_Factura.cantidad.ToString().ToLower().Contains(filtro) ||
                           detalles_Factura.sub_total.ToString().ToLower().Contains(filtro.ToLower());
                }
                return false;
            };
            filtrar_datagrid_Compra.Refresh();
        }

        private void txt_Borrar_Click(object sender, RoutedEventArgs e)
        {
            Borrar_Carrito();
        }
        private void Borrar_Carrito()
        {
            var elementoSeleccionado = dtg_Tabla_Compra.SelectedItem as Detalles_Factura;
            if (elementoSeleccionado != null)
            {
                lista_Tipos_Compra.Remove(elementoSeleccionado);
                int cantidad = int.Parse(txt_Cantidad.Text);
                Servicio_Producto servicio_Producto = new Servicio_Producto();
                Producto producto = elementoSeleccionado.producto;
                producto.stock = elementoSeleccionado.cantidad;
                servicio_Producto.Sumar_Stock(producto,cantidad);
                filtrar_datagrid_Compra.Refresh();
                Llenar_DataGrid_Producto();
            }
        }

        private void txt_Total_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Pagar_Click(object sender, RoutedEventArgs e)
        {
            Guardar_Datos_Factura();
            Guardar_Datos_Detalle_Factura();
        }
    }
}
