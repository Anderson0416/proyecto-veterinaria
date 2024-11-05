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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Registrar_Tipo_Consulta.xaml
    /// </summary>
    public partial class Registrar_Tipo_Consulta : UserControl
    {
        Servicio_Tipo_Consulta servicio_tipo_consulta;
        private ObservableCollection<Tipo_Consulta> lista_Tipos_Consultas;
        private ICollectionView filtrar_datagrid;
        public Registrar_Tipo_Consulta()
        {
            InitializeComponent();
            servicio_tipo_consulta = new Servicio_Tipo_Consulta();
            LlenarDataGrid();
        }

        private void txt_buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_buscar.Text.ToLower();

            filtrar_datagrid.Filter = item =>
            {
                if (item is Tipo_Consulta tipo_Consulta)
                {
                    return tipo_Consulta.nombre.ToLower().Contains(filtro) ||
                           tipo_Consulta.descripcion.ToLower().Contains(filtro) ||
                           tipo_Consulta.precio.ToString().ToLower().Contains(filtro.ToLower());
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
        private void LlenarDataGrid()
        {
            Servicio_Tipo_Consulta servicio_tipo = new Servicio_Tipo_Consulta();
            lista_Tipos_Consultas = new ObservableCollection<Tipo_Consulta>(servicio_tipo.Lista_Tipo_Consulta());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_Tipos_Consultas);
            dtg_Tabla_Tipo_Consulta.ItemsSource = filtrar_datagrid;
        }
        private Tipo_Consulta Datos_Tipo_Consulta()
        {
            Tipo_Consulta tipo_Consulta = new Tipo_Consulta();

            tipo_Consulta.id = int.Parse(lb_Id.Content.ToString());
            tipo_Consulta.nombre = txt_Nombre.Text;
            tipo_Consulta.descripcion = txt_Descripcion.Text;
            tipo_Consulta.precio = decimal.Parse(txt_Precio.Text);
            return tipo_Consulta;
        }
        private void Borrar_Datos()
        {
            lb_Id.Content = "";
            txt_Nombre.Clear();
            txt_Descripcion.Clear();
            txt_Precio.Clear();
        }
        public void seleccionar_valor()
        {
            var Tipo_Consulta_Seleccionado = dtg_Tabla_Tipo_Consulta.SelectedItem as Tipo_Consulta;

            if (Tipo_Consulta_Seleccionado != null)
            {
                lb_Id.Content = Tipo_Consulta_Seleccionado.id.ToString();
                txt_Nombre.Text = Tipo_Consulta_Seleccionado.nombre;
                txt_Descripcion.Text = Tipo_Consulta_Seleccionado.descripcion;
                txt_Precio.Text = Tipo_Consulta_Seleccionado.precio.ToString();
            }
        }
        public void Eliminar()
        {
            Tipo_Consulta tipo_Consulta = new Tipo_Consulta();
            tipo_Consulta = Datos_Tipo_Consulta();
            var respuesta = servicio_tipo_consulta.Eliminar_Tipo_Consulta(tipo_Consulta);
            MessageBox.Show(respuesta);
        }
        public void Actualizar()
        {
            Tipo_Consulta tipo_Consulta = new Tipo_Consulta();
            tipo_Consulta.id = int.Parse(lb_Id.Content.ToString());
            tipo_Consulta = Datos_Tipo_Consulta();
            var respuesta = servicio_tipo_consulta.Actualizar_Tipo_Consulta(tipo_Consulta);
            MessageBox.Show(respuesta);

        }

        private void dtg_Tabla_propietarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionar_valor();
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
        private void Guardar()
        {
            Tipo_Consulta tipo_Consulta = new Tipo_Consulta();

            tipo_Consulta.nombre = txt_Nombre.Text;
            tipo_Consulta.descripcion = txt_Descripcion.Text;
            tipo_Consulta.precio = decimal.Parse(txt_Precio.Text);
         
            try
            {
                string respuesta = servicio_tipo_consulta.Guardar_Tipo_Consulta(tipo_Consulta);

                MessageBox.Show(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
