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
using Veterinaria_.Views_Menu_Admin;

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Menu_Admin.xaml
    /// </summary>
    public partial class Menu_Admin : Window
    {
        public Menu_Admin()
        {
            InitializeComponent();
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

        private void btn_Registrar_Click(object sender, RoutedEventArgs e)
        {
            Registrar_Usuarios registrar_Usuarios = new Registrar_Usuarios();
            registrar_Usuarios.Show();
            this.Close();
        }

        private void Registrar_Veterinario_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Registrar_Veterinario();
            
        }

        private void Registrar_Recepcionista_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Registrar_Recepcionista();
        }

        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Consultar();
        }

    
    }
}
