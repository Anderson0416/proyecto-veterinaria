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
    /// Lógica de interacción para Consultar_Recepcionista.xaml
    /// </summary>
    public partial class Consultar_Recepcionista : UserControl
    {
        Servicio_Recepcionista Servicio_recepcionista;
        private ObservableCollection<Recepcionista> lista_recepcionistas;
        private ICollectionView filtrar_datagrid;
        int id_Recepcionista = 0;
        public Consultar_Recepcionista()
        {
            InitializeComponent();
            LlenarDataGrid();
            Servicio_recepcionista = new Servicio_Recepcionista();
        }
        private void LlenarDataGrid()
        {
            Servicio_Recepcionista servicio_recepcionista = new Servicio_Recepcionista();
            lista_recepcionistas = new ObservableCollection<Recepcionista>(servicio_recepcionista.Lista_Todos_Recepcionistas());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_recepcionistas);
            dtg_Tabla_Recepcionistas.ItemsSource = filtrar_datagrid;
        }
        private void Borrar_Datos()
        {
            txt_Numero_documento.Clear();
            cmb_Tipo_documento.SelectedIndex = -1;
            txt_Nombre.Clear();
            txt_Apellido.Clear();
            cmb_Sexo.SelectedIndex = -1;
            dtp_Fecha.SelectedDate = null;
            dtp_Fecha_contrato.SelectedDate = null;
            txt_Telefono.Clear();
        }
        private Recepcionista Datos_Recepcionista()
        {
            Recepcionista recepcionista = new Recepcionista();
            recepcionista.id = id_Recepcionista;
            recepcionista.documento = txt_Numero_documento.Text;
            recepcionista.tipo_documento = cmb_Tipo_documento.Text;
            recepcionista.nombre = txt_Nombre.Text;
            recepcionista.apellido = txt_Apellido.Text;
            recepcionista.sexo = cmb_Sexo.Text;
            recepcionista.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            recepcionista.fecha_contrato = dtp_Fecha_contrato.SelectedDate.Value;
            recepcionista.telefono = txt_Telefono.Text;
            return recepcionista;
        }
        public void seleccionar_valor()
        {
            var Recepcionista_Seleccionado = dtg_Tabla_Recepcionistas.SelectedItem as Recepcionista;

            if (Recepcionista_Seleccionado != null)
            {
                id_Recepcionista = Recepcionista_Seleccionado.id;
                txt_Nombre.Text = Recepcionista_Seleccionado.nombre;
                txt_Apellido.Text = Recepcionista_Seleccionado.apellido;
                txt_Numero_documento.Text = Recepcionista_Seleccionado.documento;

                if (Recepcionista_Seleccionado.Fecha_nacimiento != null)
                {
                    dtp_Fecha.SelectedDate = Recepcionista_Seleccionado.Fecha_nacimiento;
                }
                if (Recepcionista_Seleccionado.fecha_contrato != null)
                {
                    dtp_Fecha_contrato.SelectedDate = Recepcionista_Seleccionado.fecha_contrato;
                }

                txt_Telefono.Text = Recepcionista_Seleccionado.telefono;

                foreach (ComboBoxItem item in cmb_Sexo.Items)
                {
                    if (item.Content.ToString() == Recepcionista_Seleccionado.sexo)
                    {
                        cmb_Sexo.SelectedItem = item;
                        break;
                    }
                }

                foreach (ComboBoxItem item in cmb_Tipo_documento.Items)
                
                    if (item.Content.ToString() == Recepcionista_Seleccionado.tipo_documento)
                    {
                        cmb_Tipo_documento.SelectedItem = item;
                        break;
                    }
            }
        }

        private void dtg_Tabla_Recepcionistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionar_valor();
        }
        private bool FiltrarPorFecha(DateTime fechaCita, string filtro)
        {
            if (int.TryParse(filtro, out int numero))
            {
                bool esDia = (numero >= 1 && numero <= 31 && fechaCita.Day == numero);
                bool esMes = (numero >= 1 && numero <= 12 && fechaCita.Month == numero);

                return esDia || esMes;
            }
            return false;
        }
        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar.Text.ToLower();

            filtrar_datagrid.Filter = item =>
            {
                if (item is Recepcionista recepcionista)
                {
                    return recepcionista.nombre.ToLower().Contains(filtro) ||
                           recepcionista.apellido.ToLower().Contains(filtro) ||
                           FiltrarPorFecha(recepcionista.Fecha_nacimiento, filtro) ||
                           FiltrarPorFecha(recepcionista.fecha_contrato, filtro) ||
                           recepcionista.documento.ToLower().Contains(filtro);
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
        public void Eliminar()
        {
            Recepcionista recepcionista = new Recepcionista();
            recepcionista = Datos_Recepcionista();
            var respuesta = Servicio_recepcionista.Eliminar_Recepcionista(recepcionista);
            MessageBox.Show(respuesta);
        }
        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Borrar_Datos();
            LlenarDataGrid();
        }
        public void Actualizar()
        {
            Recepcionista recepcionista = new Recepcionista();
            recepcionista = Datos_Recepcionista();
            var respuesta = Servicio_recepcionista.Actualizar_Recepcionista(recepcionista);
            MessageBox.Show(respuesta);

        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            Borrar_Datos();
            LlenarDataGrid();
        }
    }
}
