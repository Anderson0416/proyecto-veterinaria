using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using Veterinaria_.Views;
using Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion;

namespace Veterinaria_.Views_Menu_Recepcion
{
    public partial class Pagar_Consulta : Window
    {
        private List<Cita_Tipo_Consulta> consultas_Seleccionadas = new List<Cita_Tipo_Consulta>();
        int id_cita = 0;
        int id_ultima_cita = 0;
        public Pagar_Consulta(UserControl controlActual)
        {
            InitializeComponent();
            AsignarIdCita(controlActual);
            Llenar_Datos_Cita();
        }
        
        public void AsignarIdCita(UserControl controlActual)
        {
            if (controlActual is Programar_Consulta programarConsulta)
            {
                id_cita = programarConsulta.Id_Ultima_cita();
            }
            else if (controlActual is Consulta_Cita consultaCita)
            {
                id_ultima_cita = consultaCita.Id_cita();
            }
        }

        private Citas Consultar_Cita()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            int id = id_cita != 0 ? id_cita : id_ultima_cita;

            return id != 0 ? servicio_cita.Cita_Id(id) : new Citas();
        }
        private void Llenar_Datos_Cita()
        {
            Citas cita = Consultar_Cita();

            if (cita != null)
            {
                txt_Id_Cita.Text = cita.id.ToString();
                txt_Nombre_Propietario.Text = cita.propietario?.nombre ?? string.Empty;
                txt_Nombre_Mascota.Text = cita.mascota?.nombre ?? string.Empty;
                txt_Nombre_Veterinario.Text = cita.veterinario?.nombre ?? string.Empty;
                txt_Descripcion_Consulta.Text = cita.nota ?? string.Empty;
                txt_Total_Pagar.Text = cita.total_pagar.ToString();
                dtp_Fecha_Consulta.SelectedDate = cita.fecha_cita;

                Llenar_Tabla(cita.id);
            }
        }
        private void Llenar_Tabla(int id)
        {
            Servicio_Cita_Tipo_Consulta servicio_cita_tipo_consulta = new Servicio_Cita_Tipo_Consulta();
            consultas_Seleccionadas = servicio_cita_tipo_consulta.Citas_Tipo_Consultas_Id(id);
            dtg_Tabla_Tipo_Consulta.ItemsSource = consultas_Seleccionadas;
        }
        private void Limpiar()
        {
            txt_Id_Cita.Clear();
            txt_Nombre_Propietario.Clear();
            txt_Nombre_Mascota.Clear();
            txt_Nombre_Veterinario.Clear();
            txt_Descripcion_Consulta.Clear();
            dtp_Fecha_Consulta.SelectedDate = null;
        }
        private void Guardar()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            Citas cita = Consultar_Cita();
            string respuesta = servicio_cita.Actualizar_Estado_Cita(cita.id, "pagado");
            MessageBox.Show(respuesta);
        }
        private void Calcular_Cambio()
        {
            decimal totalPagar = 0;
            decimal recibo = 0;
            if (!decimal.TryParse(txt_Total_Pagar.Text, out totalPagar))
            {
                MessageBox.Show("Por favor, ingrese un valor válido en Total Pagar.");
                return;
            }
            if (!decimal.TryParse(txt_Recibo.Text, out recibo))
            {
                MessageBox.Show("Por favor, ingrese un valor válido en Recibo.");
                return;
            }
            decimal cambio = recibo - totalPagar;

            txt_Cambio.Text = cambio.ToString("F2"); 
        }
        private void btn_Pagar_Consulta_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
            this.Close();
        }
        private void txt_Recibo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular_Cambio();
        }
    }
}
