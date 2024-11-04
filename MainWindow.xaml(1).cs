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

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Inicio_Click(object sender, RoutedEventArgs e)
        {
            Servicio_Login servicio_login = new Servicio_Login();
            string respuesta = servicio_login.control_Login(txt_Usuario.Text, txt_Contraseña.Text);
            if (respuesta.Length > 0)
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                Inicio_Seccion();
            }

            
            
        }
        private void Inicio_Seccion()
        {
            Menu_Admin menu_Admin = new Menu_Admin();
            int tipo_Usuario = Seccion.Tipo_usuario;

            if (tipo_Usuario == 1)
            {
                menu_Admin.Show();
                this.Close();
            }

        }


    


    }
}
