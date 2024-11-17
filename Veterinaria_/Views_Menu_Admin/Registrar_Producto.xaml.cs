using BLL;
using Entity;
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
using System.Windows.Shapes;

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Registrar_Producto.xaml
    /// </summary>
    public partial class Registrar_Producto : UserControl
    {
        Servicio_Producto servicio_producto;
        private ObservableCollection<Producto> lista_Tipos_Productos;
        private ICollectionView filtrar_datagrid;
        public Registrar_Producto()
        {
            servicio_producto = new Servicio_Producto();
            InitializeComponent();
            LlenarDataGrid();
        }

        private void txt_Precio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtg_Tabla_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionar_valor();
        }

        private void txt_buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_buscar.Text.ToLower();

            filtrar_datagrid.Filter = item =>
            {
                if (item is Producto producto)
                {
                    return producto.nombre.ToLower().Contains(filtro) ||
                           producto.descripcion.ToLower().Contains(filtro) ||
                           producto.precio.ToString().ToLower().Contains(filtro) ||
                           producto.stock.ToString().ToLower().Contains(filtro.ToLower() );
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
        private void LlenarDataGrid()
        {
            Servicio_Producto servicio_producto = new Servicio_Producto();
            lista_Tipos_Productos = new ObservableCollection<Producto>(servicio_producto.Lista_Productos());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_Tipos_Productos);
            dtg_Tabla_Producto.ItemsSource = filtrar_datagrid;
        }
        private Producto Datos_Producto()
        {
            Producto producto = new Producto();
            if (lb_Id.Content != null && !string.IsNullOrWhiteSpace(lb_Id.Content.ToString()))
            {
                try
                {
                    producto.id = int.Parse(lb_Id.Content.ToString());
                }
                catch (FormatException)
                {
                    MessageBox.Show("El contenido no tiene el formato correcto para ser un número.");
                }
            }
            producto.nombre = txt_Nombre.Text;
            producto.precio = decimal.Parse(txt_Precio.Text);
            producto.stock = int.Parse(txt_Stock.Text);
            producto.descripcion = txt_Descripcion.Text;
            return producto;
        }
        private void Borrar_Datos()
        {
            lb_Id.Content = "";
            txt_Nombre.Clear();
            txt_Descripcion.Clear();
            txt_Precio.Clear();
            txt_Stock.Clear();
        }
        public void seleccionar_valor()
        {
            var Producto_Seleccionado = dtg_Tabla_Producto.SelectedItem as Producto;

            if (Producto_Seleccionado != null)
            {
                lb_Id.Content = Producto_Seleccionado.id.ToString();
                txt_Nombre.Text = Producto_Seleccionado.nombre;
                txt_Descripcion.Text = Producto_Seleccionado.descripcion;
                txt_Precio.Text = Producto_Seleccionado.precio.ToString();
                txt_Stock.Text = Producto_Seleccionado.stock.ToString();
            }
        }
        public void Eliminar()
        {
            Producto producto = new Producto();
            producto = Datos_Producto();
            var respuesta = servicio_producto.Eliminar_Producto(producto.id);
            MessageBox.Show(respuesta);
        }
        public void Actualizar()
        {
            Producto producto = new Producto();
            producto.id = int.Parse(lb_Id.Content.ToString());
            producto = Datos_Producto();
            var respuesta = servicio_producto.Actualizar_Producto(producto);
            MessageBox.Show(respuesta);

        }
        private void Guardar()
        {
            Producto producto = new Producto();
            producto = Datos_Producto();
            try
            {
                string respuesta = servicio_producto.Registrar_Producto(producto);
                MessageBox.Show(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Borrar_Datos();
            LlenarDataGrid();
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            LlenarDataGrid();
            Borrar_Datos();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
            Borrar_Datos();
            LlenarDataGrid();
        }
    }
}
