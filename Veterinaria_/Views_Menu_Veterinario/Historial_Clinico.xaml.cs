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

namespace Veterinaria_.Views_Menu_Veterinario
{
    /// <summary>
    /// Lógica de interacción para Historial_Clinico.xaml
    /// </summary>
    public partial class Historial_Clinico : UserControl
    {
        public Historial_Clinico()
        {
            InitializeComponent();
            CargarHistoriales();
        }
        private void CargarHistoriales()
        {
            Servicio_Historial servicio_historial = new Servicio_Historial();
            List<Historial> historiales = servicio_historial.Lista_Historial();
            dtg_Tabla_Historial.ItemsSource = historiales;
        }
        private void dtg_Tabla_Historial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Consultorio consultorioWindow = new Consultorio(this);
            consultorioWindow.Show();
        }
        private void Buscar()
        {
            Servicio_Historial servicio_historial = new Servicio_Historial();
            string filtro = txt_Buscar.Text.ToLower();
            var filtrado = servicio_historial.Lista_Historial().Where(h =>
                h.mascota.nombre.ToLower().Contains(filtro) ||
                h.anamnesis.motivo_consulta.ToLower().Contains(filtro) ||
                h.id.ToString().Contains(filtro) ||
                h.anamnesis.id.ToString().Contains(filtro) ||
                h.fecha.ToString("dd/MM/yyyy").Contains(filtro)
            ).ToList();

            dtg_Tabla_Historial.ItemsSource = filtrado;
        }
        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar();
        }

        public int id_Anamnesis()
        {
            if (dtg_Tabla_Historial.SelectedItem != null)
            {
                Historial citaSeleccionada = (Historial)dtg_Tabla_Historial.SelectedItem;

                int idCitaSeleccionada = citaSeleccionada.anamnesis.id;

                return idCitaSeleccionada;
            }

            return 0;
        }
    }
}
