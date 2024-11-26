using BLL;
using MaterialDesignThemes.Wpf;
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
using Veterinaria_.Views_Menu_Recepcion;
using Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion;




namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Menu_Recepcion.xaml
    /// </summary>
    public partial class Menu_Recepcion : Window
    {
        public Menu_Recepcion()
        {
            InitializeComponent();
            Servicio_Recordatorio servicio_Recordatorio = new Servicio_Recordatorio();
            servicio_Recordatorio.EnviarRecordatorios();
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.5;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {

            GridContent.Opacity = 1;

        }

        private void PreviewMouseLeftBottonDownBG(object sender, MouseButtonEventArgs e)
        {

            BtnShowHide.IsChecked = false;
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void Programar_Consulta_Click(object sender, RoutedEventArgs e)
        {
            DataContext =new Programar_Consulta();
        }

        private void Registrar_Propietario_Click(object sender, RoutedEventArgs e)
        {

            DataContext = new Registrar_Propietario(); 

        }

       

        private void Incorporar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            DataContext= new Incorporar_Paciente();
        }

        private void Consultar_Informacion_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.ContextMenu != null)
            {               
                button.ContextMenu.PlacementTarget = button; 
                button.ContextMenu.IsOpen = true; 
            }
        }

        // Manejadores de las opciones del submenú CONSULTAR INFORMACION
        private void Consultar_Propietarios_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Consulta_Clientes();
        }

        private void Consultar_Mascota_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Consulta_Mascota();
        }

        private void Consultar_Cita_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Consulta_Cita();
        }


        //private void Recordatorio_Cita_Click(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new Recordatorio_Cita();
 
        //}


        private void Historial_Clinico_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Historial_Clinico();
        }

       private void Compra_Click(object sender, RoutedEventArgs e) 
       {
            DataContext = new Compra();
       }

        private void Cerrar_Seccion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
