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
    /// Lógica de interacción para Consultar_Veterinario.xaml
    /// </summary>
    public partial class Consultar_Veterinario : UserControl
    {
        Servicio_Veterinario Servicio_veterinario;
        private ObservableCollection<Veterinario> lista_veterinarios;
        private ICollectionView filtrar_datagrid;
        int id_Veterinario = 0;
        public Consultar_Veterinario()
        {
            InitializeComponent();
            LlenarDataGrid();
            Servicio_veterinario = new Servicio_Veterinario();
        }
        private Veterinario Datos_Veterinario()
        {
            Veterinario veterinario = new Veterinario();
            veterinario.id = id_Veterinario;
            veterinario.documento = txt_Numero_documento.Text;
            veterinario.tipo_documento = cmb_Tipo_documento.Text;
            veterinario.nombre = txt_Nombre.Text;
            veterinario.apellido = txt_Apellido.Text;
            veterinario.sexo = cmb_Sexo.Text;
            veterinario.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            veterinario.fecha_contrato = dtp_Fecha_contrato.SelectedDate.Value;
            veterinario.telefono = txt_Telefono.Text;
            return veterinario;
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

        private void LlenarDataGrid()
        {
            Servicio_Veterinario servicio_veterinario = new Servicio_Veterinario();
            lista_veterinarios = new ObservableCollection<Veterinario>(servicio_veterinario.Lista_Todos_Veterinario());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_veterinarios);
            dtg_Tabla_Veterinarios.ItemsSource = filtrar_datagrid;
        }
        public void seleccionar_valor()
        {
            var Veterinario_Seleccionado = dtg_Tabla_Veterinarios.SelectedItem as Veterinario;

            if (Veterinario_Seleccionado != null)
            {
                id_Veterinario = Veterinario_Seleccionado.id;
                txt_Nombre.Text = Veterinario_Seleccionado.nombre;
                txt_Apellido.Text = Veterinario_Seleccionado.apellido;
                txt_Numero_documento.Text = Veterinario_Seleccionado.documento;

                if (Veterinario_Seleccionado.Fecha_nacimiento != null)
                {
                    dtp_Fecha.SelectedDate = Veterinario_Seleccionado.Fecha_nacimiento;
                }
                if (Veterinario_Seleccionado.fecha_contrato != null)
                {
                    dtp_Fecha_contrato.SelectedDate = Veterinario_Seleccionado.fecha_contrato;
                }

                txt_Telefono.Text = Veterinario_Seleccionado.telefono;

                foreach (ComboBoxItem item in cmb_Sexo.Items)
                {
                    if (item.Content.ToString() == Veterinario_Seleccionado.sexo)
                    {
                        cmb_Sexo.SelectedItem = item;
                        break;
                    }
                }

                foreach (ComboBoxItem item in cmb_Tipo_documento.Items)
                {
                    if (item.Content.ToString() == Veterinario_Seleccionado.tipo_documento)
                    {
                        cmb_Tipo_documento.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void dtg_Tabla_Veterinarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                if (item is Veterinario veterinario)
                {
                    return veterinario.nombre.ToLower().Contains(filtro) ||
                           veterinario.apellido.ToLower().Contains(filtro) ||
                           FiltrarPorFecha(veterinario.Fecha_nacimiento, filtro) ||
                           FiltrarPorFecha(veterinario.fecha_contrato, filtro) ||
                           veterinario.documento.ToLower().Contains(filtro);
                }
                return false;
            };
            filtrar_datagrid.Refresh();
        }
        public void Eliminar()
        {
            Veterinario veterinario = new Veterinario();
            veterinario = Datos_Veterinario();
            var respuesta = Servicio_veterinario.Eliminar_Veterinario(veterinario);
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
            Veterinario veterinario = new Veterinario();
            veterinario = Datos_Veterinario();
            var respuesta = Servicio_veterinario.Actualizar_Veterinario(veterinario);
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
