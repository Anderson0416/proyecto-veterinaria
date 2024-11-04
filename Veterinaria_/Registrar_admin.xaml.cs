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

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Registrar_admin.xaml
    /// </summary>
    public partial class Registrar_admin : Window
    {
        public Registrar_admin()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar_Usuario();
        }

        public void Guardar_Usuario()
        {
            Usuarios usuario = new Usuarios();

            usuario.Nombre = txt_Usuario.Text;
            usuario.Contraseña = txt_contraseña.Text;
            usuario.Confirmar_Contraseña = txt_Confimar_Contra.Text;
            usuario.Tipo_usuario = 1;

            try
            {
                Servicio_Usuarios servicio_usuarios = new Servicio_Usuarios();
                string respuesta = servicio_usuarios.Guardar_Usuario(usuario);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta);
                }
                else
                {
                    MessageBox.Show("Usuario registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
