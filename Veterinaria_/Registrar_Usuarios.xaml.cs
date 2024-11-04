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
    /// Lógica de interacción para Registrar_Usuarios.xaml
    /// </summary>
    public partial class Registrar_Usuarios : Window
    {
        public Registrar_Usuarios()
        {
            InitializeComponent();
            Mostrar_Cargo();
        }
        private void Mostrar_Cargo()
        {
            Servicio_Usuarios servicio_usuarios = new Servicio_Usuarios();
            List<Tipo_Usuario> tipo_usuarios = servicio_usuarios.Lista_Cargo();
            cmb_Cargo.ItemsSource = tipo_usuarios;
            cmb_Cargo.DisplayMemberPath = "nombre";
            cmb_Cargo.SelectedValuePath = "id";
        }

        private void btn_Registrar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = new Usuarios();

            usuario.Nombre = txt_Nombre.Text;
            usuario.Contraseña = txt_Contraseña.Text;
            usuario.Confirmar_Contraseña = txt_Confirmar_Contraseña.Text;
            usuario.Tipo_usuario = (int)cmb_Cargo.SelectedValue;

            try
            {
                Servicio_Usuarios servicio_usuarios = new Servicio_Usuarios();
                string respuesta = servicio_usuarios.Guardar_Usuario(usuario);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso");
                }
                else
                {
                    MessageBox.Show("Usuario registrado");
                    Menu_Admin menu_Admin =new Menu_Admin();
                    menu_Admin.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
