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

namespace Veterinaria_.Views
{
    /// <summary>
    /// Lógica de interacción para Registrar_Propietario.xaml
    /// </summary>
    public partial class Registrar_Propietario : UserControl
    {
        public Registrar_Propietario()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
            Borrar_Datos();
        }

        private void Guardar()
        {
            Propietario propietario = new Propietario();

            propietario.documento = txt_Numero_documento.Text;
            propietario.tipo_documento = cmb_Tipo_documento.Text;
            propietario.nombre = txt_Nombre.Text;
            propietario.apellido = txt_Apellido.Text;
            propietario.sexo = cmb_Sexo.Text;
            propietario.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            propietario.telefono = txt_Telefono.Text;


            try
            {
                Servicio_Propietario servicio_propietario = new Servicio_Propietario();
                string respuesta = servicio_propietario.Guardar_Propietario(propietario);

                MessageBox.Show(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Borrar_Datos()
        {
            txt_Numero_documento.Clear();
            cmb_Tipo_documento.SelectedIndex = -1;
            txt_Nombre.Clear();
            txt_Apellido.Clear();
            cmb_Sexo.SelectedIndex = -1;
            dtp_Fecha.SelectedDate = null;
            txt_Telefono.Clear();
        }
    }
}
