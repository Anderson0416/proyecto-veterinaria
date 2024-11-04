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
    /// Lógica de interacción para Incorporar_Paciente.xaml
    /// </summary>
    public partial class Incorporar_Paciente : UserControl
    {
        public Incorporar_Paciente()
        {
            InitializeComponent();
        }

        private void btn_Consultar_Propietario_Click(object sender, RoutedEventArgs e)
        {
            Consultar_Prpietario();
        }
        public void Consultar_Prpietario()
        {
            Servicio_Propietario servicio_propietario = new Servicio_Propietario();
            Propietario propietario = new Propietario();

            string documento = txt_Documento_Propietario.Text;
            propietario = servicio_propietario.Consultar_Propietario_Documento(documento);
            if (propietario != null)
            {
                txt_Nombre_Propietario.Text = propietario.nombre;
                txt_Apellido_Propietario.Text = propietario.apellido;
            }
            else
            {
                MessageBox.Show("PROPIETARIO NO ENCONTRADO, POR FAVOR REALIZAR EL REGISTRO");
                Borrar_Datos();
            }
        }

        private void btn_Guardar_Mascota_Click(object sender, RoutedEventArgs e)
        {
            Guardar_Mascota();
            Borrar_Datos();
        }
        
        public void Guardar_Mascota()
        {
            Mascota mascota = new Mascota();
            mascota.propietario = new Propietario();

            mascota.nombre = txt_Nombre_Mascota.Text;
            mascota.especie = txt_Especie.Text;
            mascota.raza = txt_Raza.Text;
            mascota.edad = txt_Edad.Text;
            mascota.edad2 = cmb_Edad.Text;
            mascota.sexo = cmb_Sexo.Text;
            mascota.propietario.documento = txt_Documento_Propietario.Text;

            try
            {
                Servicio_Mascota servicio_Mascota = new Servicio_Mascota();
                string respuesta = servicio_Mascota.Guardar_Mascota(mascota);
                MessageBox.Show(respuesta);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Borrar_Datos()
        {   
            txt_Documento_Propietario.Clear();
            txt_Nombre_Propietario.Clear();
            txt_Apellido_Propietario.Clear();
            txt_Nombre_Mascota.Clear();
            txt_Especie.Clear();
            txt_Raza.Clear();
            txt_Edad.Clear();
            cmb_Edad.SelectedIndex = -1;
            cmb_Sexo.SelectedIndex = -1;
        }
    }
}
