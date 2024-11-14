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
using Veterinaria_.Views_Menu_Recepcion;

namespace Veterinaria_.Views
{
    /// <summary>
    /// Lógica de interacción para Programar_Consulta.xaml
    /// </summary>
    public partial class Programar_Consulta : UserControl
    {
        private List<Tipo_Consulta> consultas_Seleccionadas = new List<Tipo_Consulta>();
        int id_Propietario = 0; 
        public Programar_Consulta()
        {
            InitializeComponent();
            Mostrar_Veterinario_cmb();
            Mostrar_Tipo_Consulta();
        }
        public void Consultar_Prpietario()
        {
            Servicio_Propietario servicio_propietario = new Servicio_Propietario();
            Propietario propietario = new Propietario();

            string documento = txt_Documento_propietario.Text;
            propietario = servicio_propietario.Consultar_Propietario_Documento(documento);
            if (propietario != null)
            {
                txt_Nombre_Propietario.Text = propietario.nombre;
                id_Propietario = propietario.id;
                Mostrar_Mascota_cmb();
            }
            else
            {
                MessageBox.Show("PROPIETARIO NO ENCONTRADO, POR FAVOR REALIZAR EL REGISTRO");
                Borrar_Datos();
            }
        }
        private void Borrar_Datos()
        {
            txt_Documento_propietario.Clear();
            txt_Nombre_Propietario.Clear();
            cmb_Nombre_Mascota.SelectedIndex = -1;
            txt_Especie.Clear();
            txt_Raza.Clear();
            txt_Edad.Clear();
            txt_Sexo.Clear();
            dtp_Fecha_Consulta.SelectedDate = null;
            cmb_Nombre_Veterinario.SelectedIndex = -1;
            cmb_Tipo_Consulta.SelectedIndex = -1;
            txt_Descripcion_Consulta.Clear();
            dtg_Tabla_Tipo_Consulta.ItemsSource = null;
        }
        private void Llenar_Datos_Mascota()
        {
            Servicio_Mascota servicio_Mascota = new Servicio_Mascota();
            
            if (cmb_Nombre_Mascota.SelectedItem != null)
            {
                int id = (int)cmb_Nombre_Mascota.SelectedValue;
                Mascota mascota = servicio_Mascota.Consultar_Mascota_Id(id);
                if (mascota != null)
                {
                    txt_Especie.Text = mascota.especie;
                    txt_Raza.Text = mascota.raza;
                    txt_Sexo.Text = mascota.sexo;
                    txt_Edad.Text = mascota.edad + " " + mascota.edad2;
                }
                else
                {
                    MessageBox.Show("No se encontró la mascota."+ id );
                }
            }
            else
            {
                MessageBox.Show("No se encontró la mascota.");
            }

        }
        private void btn_Consultar_Propietario_Click(object sender, RoutedEventArgs e)
        {
            Consultar_Prpietario();
            Mostrar_Mascota_cmb();
        }
        private void Mostrar_Mascota_cmb()
        {
            Servicio_Mascota servicio_Mascota = new Servicio_Mascota();
            List<Mascota> mascotas = servicio_Mascota.Mascotas_Propietario(txt_Documento_propietario.Text);
            cmb_Nombre_Mascota.ItemsSource = null;
            cmb_Nombre_Mascota.ItemsSource = mascotas;
            cmb_Nombre_Mascota.DisplayMemberPath = "nombre";
            cmb_Nombre_Mascota.SelectedValuePath = "id";
        }
        private void Mostrar_Veterinario_cmb()
        {
            Servicio_Veterinario servicio_Veterinario = new Servicio_Veterinario();
            List<Veterinario> veterinarios = servicio_Veterinario.Lista_Todos_Veterinario();
            cmb_Nombre_Veterinario.ItemsSource = null;
            cmb_Nombre_Veterinario .ItemsSource = veterinarios;
            cmb_Nombre_Veterinario.DisplayMemberPath = "nombre";
            cmb_Nombre_Veterinario.SelectedValuePath = "id";
        }
        private void Mostrar_Tipo_Consulta()
        {
            Servicio_Tipo_Consulta servicio_Tipo_Consulta = new Servicio_Tipo_Consulta();
            List<Tipo_Consulta> tipo_Consultas = servicio_Tipo_Consulta.Lista_Tipo_Consulta();
            cmb_Tipo_Consulta.ItemsSource = null;
            cmb_Tipo_Consulta.ItemsSource = tipo_Consultas;
            cmb_Tipo_Consulta.DisplayMemberPath = "nombre";
            cmb_Tipo_Consulta.SelectedValuePath = "id"+"nombre"+"precio";
        }
        private void Llenar_Tabla()
        {
            if (cmb_Tipo_Consulta.SelectedItem != null)
            {
                Tipo_Consulta tipo_Consulta = (Tipo_Consulta)cmb_Tipo_Consulta.SelectedItem;

                if (!consultas_Seleccionadas.Any(c => c.id == tipo_Consulta.id))
                {
                    consultas_Seleccionadas.Add(tipo_Consulta);

                    dtg_Tabla_Tipo_Consulta.ItemsSource = null;
                    dtg_Tabla_Tipo_Consulta.ItemsSource = consultas_Seleccionadas;
                    Calcular_Total_Precio();
                }
            }
        }
        private void dtg_Tabla_Mascota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void cmb_Nombre_Mascota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Llenar_Datos_Mascota();
        }
        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {
            borrar_Tabla();
        }
        private void borrar_Tabla()
        {
            if (dtg_Tabla_Tipo_Consulta.SelectedItem != null)
            {
                Tipo_Consulta tipo_Consulta = (Tipo_Consulta)dtg_Tabla_Tipo_Consulta.SelectedItem;

                consultas_Seleccionadas.Remove(tipo_Consulta);
                dtg_Tabla_Tipo_Consulta.ItemsSource = null;
                dtg_Tabla_Tipo_Consulta.ItemsSource = consultas_Seleccionadas;
                Calcular_Total_Precio();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila para eliminar.");
            }
        }
        private void Calcular_Total_Precio()
        {
            decimal total = consultas_Seleccionadas.Sum(consulta => consulta.precio);

            lb_Total.Content = $"Total a pagar por la cita es : {total:C}";
        }
        private void cmb_Tipo_Consulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Llenar_Tabla();
        }
        private void Tomar_Datos_Cita()
        {
            Servicio_Cita servicio_Cita = new Servicio_Cita();
            Citas citas = new Citas();
            citas.propietario = new Propietario();
            citas.mascota = new Mascota();
            citas.veterinario = new Veterinario();

            citas.propietario.id = id_Propietario;
            citas.mascota.id = (int)cmb_Nombre_Mascota.SelectedValue;
            citas.veterinario.id = (int)cmb_Nombre_Veterinario.SelectedValue;
            citas.fecha_cita = dtp_Fecha_Consulta.SelectedDate.Value;
            citas.estado = "No Pago";
            string totalContent = lb_Total.Content.ToString();
            string totalNumeric = totalContent.Replace("Total a pagar por la cita es : ", "").Replace("$", "").Trim();
            try
            {
                citas.total_pagar = decimal.Parse(totalNumeric, System.Globalization.NumberStyles.Any);
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del total no es válido.");
            }
            citas.nota = txt_Descripcion_Consulta.Text;
            var respuesta = servicio_Cita.Registrar_Cita(citas);
            MessageBox.Show(respuesta);
        }
        private void Tomar_Datos_Tipo_Consulta()
        {
            Servicio_Cita_Tipo_Consulta servicio_Cita_Tipo_Consulta = new Servicio_Cita_Tipo_Consulta();
            servicio_Cita_Tipo_Consulta.Guardar_Cita_Consultas(consultas_Seleccionadas);
        }
        private void btn_Programar_Consulta_Click(object sender, RoutedEventArgs e)
        {
            Tomar_Datos_Cita();
            Tomar_Datos_Tipo_Consulta();
        }
        private void btn_Pagar_Consulta_Click(object sender, RoutedEventArgs e)
        {
            Tomar_Datos_Cita();
            Tomar_Datos_Tipo_Consulta();
            Pagar_Consulta pagar_Consulta = new Pagar_Consulta(this);
            pagar_Consulta.Show();
        }
        public int Id_Ultima_cita()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            return servicio_cita.Ultima_Cita_Registrada();
        }
        
    }
}
