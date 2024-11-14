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
using System.Windows.Shapes;
using Veterinaria_.Views;
using Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion;
using Veterinaria_.Views_Menu_Veterinario;

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Consultorio.xaml
    /// </summary>
    public partial class Consultorio : Window
    {
        private int id_Cita;
        private int id_Anamnesis;
        private int id_Historial;
        public Consultorio(UserControl controlActual)
        {
            InitializeComponent();
            AsignarIdCita(controlActual);
            CargarCita(id_Cita);
            llenar_Datos_Anamnesis();
        }
        public void AsignarIdCita(UserControl controlActual)
        {
            if (controlActual is Mis_Citas mis_citas)
            {
                id_Cita = mis_citas.id_Cita();
            }
            else if (controlActual is Views_Menu_Veterinario.Historial_Clinico historial_clinico)
            {
                id_Anamnesis = historial_clinico.id_Anamnesis();
            }
        }
        private void CargarCita(int id)
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            Citas cita = servicio_cita.Cita_Id(id);

            // Verificar si cita es null
            if (cita != null)
            {
                // Si la cita no es null, entonces asignamos los valores
                txt_Id_Mascota.Text = cita.mascota.id.ToString();
                txt_Codigo_Cita.Text = cita.id.ToString();
                txt_Nombre_Mascota.Text = cita.mascota.nombre;
                txt_Descripcion.Text = cita.nota;
            }
        }
        public void Agregar_Historial()
        {
            Historial historial = new Historial();
            historial.mascota = new Mascota { id = int.Parse(txt_Id_Mascota.Text) };
            Servicio_Historial servicio_historial = new Servicio_Historial();
            id_Historial = servicio_historial.Registrar_Historial(historial);
        }
        private void Guardar_Anamnesis()
        {
            Anamnesis anamnesis = new Anamnesis();

            anamnesis.peso = int.Parse(txt_Peso1.Text);
            anamnesis.peso2 = txt_Peso2.Text;
            anamnesis.estado_reproductivo = cmb_Estado_Reproductivo.Text;
            anamnesis.actividad_fisica = cmb_Actividad_Fisica.Text;
            anamnesis.tipo_vivienda = cmb_Tipo_Vivienda.Text;
            anamnesis.vacunas_previas = txt_Vacunas_Previas.Text;
            anamnesis.vacunas_precias_desparecitacion = txt_Vacunas_Previas_Desparasitacion.Text;
            anamnesis.motivo_consulta = txt_Descripcion.Text;
            anamnesis.sintomas_mascota = txt_Sintomas_Mascota.Text;
            anamnesis.observaciones = txt_Observaciones_Adicionales.Text;
            anamnesis.dieta = txt_Dieta_Alimentacion.Text;
            anamnesis.historal = new Historial { id = id_Historial };

            Servicio_Anamnesis servicio_anamnesis = new Servicio_Anamnesis();
            string respuesta = servicio_anamnesis.Guardar_Anamnesis(anamnesis);
            MessageBox.Show(respuesta);
        }
        private void Eliminar_Cita()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            int id = int.Parse(txt_Codigo_Cita.Text);
            Citas cita = servicio_cita.Cita_Id(id);
            servicio_cita.Eliminar_Citas(cita);
        }
        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Agregar_Historial();
            Eliminar_Cita(); 
            Guardar_Anamnesis();
            
        }
        private void Seleccionar_Vacunas()
        {
            if (cmb_Vacunas_Previas.SelectedItem is ComboBoxItem selectedItem)
            {
                string seleccion = selectedItem.Content.ToString();
                if (!txt_Vacunas_Previas.Text.Contains(seleccion))
                {
                    txt_Vacunas_Previas.AppendText(seleccion + Environment.NewLine);
                }
            }
        }
        private void cmb_Vacunas_Previas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seleccionar_Vacunas();
        }
        private void Seleccionar_Desparasitacion()
        {
            if (cmb_Vacunas_Previas_Desparasitacion.SelectedItem is ComboBoxItem selectedItem)
            {
                string seleccion = selectedItem.Content.ToString();
                if (!txt_Vacunas_Previas_Desparasitacion.Text.Contains(seleccion))
                {
                    txt_Vacunas_Previas_Desparasitacion.AppendText(seleccion + Environment.NewLine);
                }
            }
        }
        private void cmb_Vacunas_Previas_Desparasitacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seleccionar_Desparasitacion();
        }
        public void llenar_Datos_Anamnesis()
        {
            if (id_Anamnesis != 0)
            {
                Anamnesis anamnesis = new Anamnesis();
                Servicio_Anamnesis servicio_anamnesis = new Servicio_Anamnesis();
                anamnesis = servicio_anamnesis.Obtener_Anamnesis_Id(id_Anamnesis);


                txt_Peso1.Text = anamnesis.peso.ToString();
                txt_Peso2.Text = anamnesis.peso2.ToString();
                txt_Vacunas_Previas.Text = anamnesis.vacunas_previas;
                txt_Vacunas_Previas_Desparasitacion.Text = anamnesis.vacunas_precias_desparecitacion;
                cmb_Actividad_Fisica.Text = anamnesis.actividad_fisica;
                cmb_Estado_Reproductivo.Text = anamnesis.estado_reproductivo;
                cmb_Tipo_Vivienda.Text = anamnesis.tipo_vivienda;
                txt_Motivo_Consulta.Text = anamnesis.motivo_consulta;
                txt_Sintomas_Mascota.Text = anamnesis.sintomas_mascota;
                txt_Observaciones_Adicionales.Text = anamnesis.observaciones;
                txt_Dieta_Alimentacion.Text = anamnesis.dieta;
                txt_Nombre_Mascota.Text = anamnesis.historal.mascota.nombre;
                txt_Id_Mascota.Text = anamnesis.historal.mascota.id.ToString();
                txt_Codigo_Cita.Visibility = Visibility.Collapsed;
                lb_Codigo_cita.Visibility = Visibility.Collapsed;
                txt_Descripcion.Visibility = Visibility.Collapsed;
                lb_Descripcion.Visibility = Visibility.Collapsed;
            }
        }
    }
}
