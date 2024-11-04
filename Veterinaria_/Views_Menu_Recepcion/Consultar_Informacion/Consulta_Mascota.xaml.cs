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
using BLL;
using Entity;

namespace Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion
{
    /// <summary>
    /// Lógica de interacción para Consulta_Mascota.xaml
    /// </summary>
    public partial class Consulta_Mascota : UserControl
    {
        Servicio_Mascota Servicio_mascota;
        private ObservableCollection<Mascota> lista_Mascotas;
        private ICollectionView filtrar_datagrid;

        public Consulta_Mascota()
        {
            InitializeComponent();
            LlenarDataGrid();
            Servicio_mascota = new Servicio_Mascota();

        }
        public Mascota Datos_Mascota()
        {
            Mascota mascota = new Mascota();
            mascota.propietario = new Propietario();
            mascota.id = int.Parse(lb_Id.Content.ToString());
            mascota.propietario.documento = lb_Documento_propietario.Content.ToString();
            mascota.nombre = txt_Nombre_mascota.Text;
            mascota.especie = txt_Especie.Text;
            mascota.raza = txt_Raza.Text;
            mascota.sexo = cmb_Sexo.Text;
            mascota.edad = txt_Edad.Text;
            mascota.edad2 = cmb_Edad.Text;
            return mascota;
        }

        public void Borrar_Datos()
        {
            lb_Id.Content = "";
            lb_Documento_propietario.Content = "";
            txt_Nombre_mascota.Clear();
            txt_Especie.Clear();
            txt_Raza.Clear();
            txt_Edad.Clear();
            cmb_Edad.SelectedIndex = -1;
            cmb_Sexo.SelectedIndex = -1;
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Borrar_Datos();
            LlenarDataGrid();
        }
        public void Eliminar()
        {
            Mascota mascota = new Mascota();
            mascota = Datos_Mascota();
            var respuesta = Servicio_mascota.Eliminar_Mascota(mascota);
            MessageBox.Show(respuesta);
        }
        private void LlenarDataGrid()
        {
            Servicio_Mascota servicio_mascota = new Servicio_Mascota();
            lista_Mascotas = new ObservableCollection<Mascota>(servicio_mascota.Lista_Todos_Mascota());
            filtrar_datagrid = CollectionViewSource.GetDefaultView(lista_Mascotas);
            dtg_Tabla_mascota.ItemsSource = filtrar_datagrid;
        }

        private void dtg_Tabla_Mascota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selevionar_Datos();
        }

        public void Selevionar_Datos()
        {
            var Mascota_Seleccionada = dtg_Tabla_mascota.SelectedItem as Mascota;

            if (Mascota_Seleccionada != null)
            {
                lb_Id.Content = Mascota_Seleccionada.id.ToString();
                txt_Nombre_mascota.Text = Mascota_Seleccionada.nombre;
                txt_Especie.Text = Mascota_Seleccionada.especie;
                txt_Raza.Text = Mascota_Seleccionada.raza;
                txt_Edad.Text = Mascota_Seleccionada.edad;
                lb_Documento_propietario.Content = Mascota_Seleccionada.propietario.documento.ToString();
                foreach (ComboBoxItem item in cmb_Sexo.Items)
                {
                    if (item.Content.ToString() == Mascota_Seleccionada.sexo)
                    {
                        cmb_Sexo.SelectedItem = item;
                        break;
                    }
                }
                foreach (ComboBoxItem item in cmb_Edad.Items)
                {
                    if (item.Content.ToString() == Mascota_Seleccionada.edad2)
                    {
                        cmb_Edad.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar.Text.ToLower();
            filtrar_datagrid.Filter = (item) =>
            {
                var mascota = item as Mascota;
                if (mascota == null) return false;

                return (mascota.nombre.ToLower().Contains(filtro) ||
                        mascota.propietario.documento.ToLower().Contains(filtro) ||
                        mascota.especie.ToLower().Contains(filtro) ||
                        mascota.raza.ToLower().Contains(filtro));
            };

            filtrar_datagrid.Refresh();
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            LlenarDataGrid();
        }
        public void Actualizar()
        {
            Mascota mascota = new Mascota();
            mascota = Datos_Mascota();
            var respuesta = Servicio_mascota.Actualizar_Mascota(mascota);
            MessageBox.Show(respuesta);

        }
    }
}
