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

        private void btn_Registrar_Click(object sender, RoutedEventArgs e)
        {
            Registrar_Usuarios registrar_Usuarios = new Registrar_Usuarios();
            registrar_Usuarios.Show();
            this.Close();
        }
    }
}
