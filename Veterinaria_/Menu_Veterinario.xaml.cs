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
using Veterinaria_.Views_Menu_Recepcion;
using Veterinaria_.Views_Menu_Veterinario;

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Menu_Veterinario.xaml
    /// </summary>
    public partial class Menu_Veterinario : Window
    {
        public Menu_Veterinario()
        {
            InitializeComponent();
            
            MessageBox.Show("hola");
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

        private void Mis_Citas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Mis_Citas ();
        }



        private void Historial_Clinico_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Historial_Clinico();
        }

        private void Cerrar_Seccion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
