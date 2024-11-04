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

namespace Veterinaria_.Views
{
    /// <summary>
    /// Lógica de interacción para Consulta_Clientes.xaml
    /// </summary>
    public partial class Consulta_Clientes : UserControl
    {
        Servicio_Propietario servicio_propietario;
        private ObservableCollection<Propietario> lista_Propietarios;
        private ICollectionView filtrar_datagrid;

        public Consulta_Clientes()
        {
            InitializeComponent();
            LlenarDataGrid();
            servicio_propietario = new Servicio_Propietario();
        }

        private Propietario Datos_Propietario()
        {
            Propietario propietario = new Propietario();
            propietario.id = int.Parse(lb_Id.Content.ToString());
            propietario.documento = txt_Numero_documento.Text;
            propietario.tipo_documento = cmb_Tipo_documento.Text;
            propietario.nombre = txt_Nombre.Text;
            propietario.apellido = txt_Apellido.Text;
            propietario.sexo = cmd_Sexo.Text;
            propietario.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            propietario.telefono = txt_Telefono.Text;
            return propietario;
        }
        private void Borrar_Datos()
        {
            lb_Id.Content = "";
            txt_Numero_documento.Clear(); 
            cmb_Tipo_documento.SelectedIndex = -1; 
            txt_Nombre.Clear();
            txt_Apellido.Clear(); 
            cmd_Sexo.SelectedIndex = -1; 
            dtp_Fecha.SelectedDate = null; 
            txt_Telefono.Clear(); 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LlenarDataGrid()
        {
            Servicio_Propietario servicio_propietario = new Servicio_Propietario();
            lista_Propietarios = new ObservableCollection<Propietario>(servicio_propietario.Lista_Todos_Propietarios());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_Propietarios);
            dtg_Tabla_propietarios.ItemsSource = filtrar_datagrid;
        }

        private void dtg_Tabla_propietarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionar_valor();
        }

        public void seleccionar_valor()
        {
            var propietarioSeleccionado = dtg_Tabla_propietarios.SelectedItem as Propietario;

            if (propietarioSeleccionado != null)
            {
                lb_Id.Content = propietarioSeleccionado.id.ToString();
                txt_Nombre.Text = propietarioSeleccionado.nombre;
                txt_Apellido.Text = propietarioSeleccionado.apellido;
                txt_Numero_documento.Text = propietarioSeleccionado.documento;

                if (propietarioSeleccionado.Fecha_nacimiento != null)
                {
                    dtp_Fecha.SelectedDate = propietarioSeleccionado.Fecha_nacimiento;
                }

                txt_Telefono.Text = propietarioSeleccionado.telefono;

                foreach (ComboBoxItem item in cmd_Sexo.Items)
                {
                    if (item.Content.ToString() == propietarioSeleccionado.sexo)
                    {
                        cmd_Sexo.SelectedItem = item;
                        break;
                    }
                }

                foreach (ComboBoxItem item in cmb_Tipo_documento.Items)
                {
                    if (item.Content.ToString() == propietarioSeleccionado.tipo_documento)
                    {
                        cmb_Tipo_documento.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Borrar_Datos();
            LlenarDataGrid();
        }

        public void Eliminar()
        {
            Propietario propietario = new Propietario();
            propietario = Datos_Propietario();
            var respuesta = servicio_propietario.Eliminar_Proprietario(propietario);
            MessageBox.Show(respuesta);
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            LlenarDataGrid();
        }

        public void Actualizar()
        {
            Propietario propietario = new Propietario();
            propietario = Datos_Propietario();
            var respuesta = servicio_propietario.Actualizar_Propietario(propietario);
            MessageBox.Show(respuesta);

        }

        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar.Text.ToLower();

            filtrar_datagrid.Filter = item =>
            {
                if (item is Propietario propietario)
                {
                    return propietario.nombre.ToLower().Contains(filtro) ||
                           propietario.apellido.ToLower().Contains(filtro) ||
                           propietario.documento.ToLower().Contains(filtro);
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
    }
}
