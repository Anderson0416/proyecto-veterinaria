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
    /// Lógica de interacción para Mis_Citas.xaml
    /// </summary>
    public partial class Mis_Citas : UserControl
    {
        private List<Citas> listaCitasOriginal;
        public Mis_Citas()
        {
            InitializeComponent();
            Llenar_Tabla_Citas();
        }
        private void Llenar_Tabla_Citas()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            listaCitasOriginal = servicio_cita.Lista_Citas_Veterinario(Seccion.veterinario.id);
            dtg_Tabla_Citas.ItemsSource = listaCitasOriginal;
        }
        private void Selecionar_Cita()
        {
            Consultorio consultorioWindow = new Consultorio(this);
            consultorioWindow.Show();
        }

        public int id_Cita()
        {
            if (dtg_Tabla_Citas.SelectedItem != null)
            {
                Citas citaSeleccionada = (Citas)dtg_Tabla_Citas.SelectedItem;

                int idCitaSeleccionada = citaSeleccionada.id;

                return idCitaSeleccionada;
            }
          return 0;
        }

        private void dtg_Tabla_Citas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selecionar_Cita();
        }
    }
}
