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

namespace Veterinaria_.Views_Menu_Admin
{
    /// <summary>
    /// Lógica de interacción para Registrar_Veterinario.xaml
    /// </summary>
    public partial class Registrar_Veterinario : UserControl
    {
        public Registrar_Veterinario()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar_Usuario();
            Guardar_Veterinario();
        }
        public void Guardar_Veterinario()
        {
            Veterinario veterinario = new Veterinario();
            veterinario.usuario = new Usuarios();

            veterinario.documento = txt_Numero_documento.Text;
            veterinario.tipo_documento = cmb_Tipo_documento.Text;
            veterinario.nombre = txt_Nombre.Text;
            veterinario.apellido = txt_Apellido.Text;
            veterinario.sexo = cmb_Sexo.Text;
            veterinario.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            veterinario.fecha_contrato = dtp_Fecha_contrato.SelectedDate.Value;
            veterinario.telefono = txt_Telefono.Text;
            veterinario.usuario.Nombre = txt_Usuario.Text;
            try
            {
                Servicio_Veterinario servicio_veterinario = new Servicio_Veterinario();
                string respuesta = servicio_veterinario.Guardar_Veterinario(veterinario);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Guardar_Usuario()
        {
            Usuarios usuario = new Usuarios();

            usuario.Nombre = txt_Nombre.Text;
            usuario.Contraseña = txt_Contraseña.Text;
            usuario.Confirmar_Contraseña = txt_Confirmar_contraseña.Text;
            usuario.Tipo_usuario = 3;

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
