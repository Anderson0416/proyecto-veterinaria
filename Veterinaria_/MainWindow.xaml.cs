using BLL;
using Entity;
using System.Windows;
using System.Windows.Input;

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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            tomar_datos();
        }

        public void Iniciar_Seccion()
        {
            Menu_Admin menu_admin = new Menu_Admin();
            Menu_Recepcion menu_recepcio = new Menu_Recepcion();
            Menu_Veterinario menu_veterinario = new Menu_Veterinario();
            int tipo_Usuario = Seccion.Tipo_usuario;

            if(tipo_Usuario == 1)
            {
                menu_admin.Show();
                this.Close();
            }

            if (tipo_Usuario == 2)
            {
                menu_recepcio.Show();
                this.Close();
            }

            if (tipo_Usuario == 3)
            {
                menu_veterinario.Show();
                this.Close();
            }
        }
        public void tomar_datos()
        {
            Servicio_Login servicio_login = new Servicio_Login();
            Usuarios usuario = new Usuarios();
            usuario.Nombre = txt_Usuario.Text;
            usuario.Contraseña = txt_Contraseña.Password;
            string respuesta = servicio_login.control_Login(usuario);
            if (respuesta.Length > 0)
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                Iniciar_Seccion();
            }
        }
    }
}
