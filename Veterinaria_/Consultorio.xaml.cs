using BLL;
using Entity;
using Microsoft.Win32;
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

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

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

        private void btn_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog descargar_consulta = new SaveFileDialog();
            descargar_consulta.FileName = DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            descargar_consulta.Filter = "PDF Files (*.pdf)|*.pdf";

            string PaginaHTML_Texto = Properties.Resources.plantilla.ToString();

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID_MASCOTA", txt_Id_Mascota.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBRE_MASCOTA", txt_Nombre_Mascota.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@VACUNAS_PREVIAS",
                (cmb_Vacunas_Previas.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@VACUNAS_DESPARASITACION",
                (cmb_Vacunas_Previas_Desparasitacion.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ACTIVIDAD_FISICA",
                (cmb_Actividad_Fisica.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ESTADO_REPRODUCTIVO",
                (cmb_Estado_Reproductivo.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TIPO_VIVIENDA",
                (cmb_Tipo_Vivienda.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PESO1", txt_Peso1.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MOTIVO_CONSULTA", txt_Motivo_Consulta.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SINTOMAS", txt_Sintomas_Mascota.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@OBSERVACIONES", txt_Observaciones_Adicionales.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DIETA", txt_Dieta_Alimentacion.Text);


            string filas = string.Empty;

            foreach (var item in GridConsulta.Children)
            {

                var row = item as Anamnesis;

                if (row != null)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.peso.ToString() + "</td>"; // Peso 1
                    filas += "<td>" + row.vacunas_previas + "</td>"; // Vacunas previas
                    filas += "<td>" + row.vacunas_precias_desparecitacion + "</td>"; // Vacunas + desparasitación
                    filas += "<td>" + row.actividad_fisica + "</td>"; // Actividad física
                    filas += "<td>" + row.estado_reproductivo + "</td>"; // Estado reproductivo
                    filas += "<td>" + row.tipo_vivienda + "</td>"; // Tipo de vivienda
                    filas += "<td>" + row.motivo_consulta + "</td>"; // Motivo consulta
                    filas += "<td>" + row.sintomas_mascota + "</td>"; // Síntomas
                    filas += "<td>" + row.observaciones + "</td>"; // Observaciones adicionales
                    filas += "<td>" + row.dieta + "</td>"; // Dieta y alimentación
                    filas += "<td>" + row.historal.mascota.nombre + "</td>"; // Nombre de la mascota
                    filas += "<td>" + row.historal.mascota.id.ToString() + "</td>"; // ID de la mascota
                    filas += "</tr>";
                }
            }

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);


            if (descargar_consulta.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(descargar_consulta.FileName, FileMode.Create))
                {
                    // Crear y configurar el documento PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    // Agregar contenido HTML al documento
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF guardado con éxito", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
