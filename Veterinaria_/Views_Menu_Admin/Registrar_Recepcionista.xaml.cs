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
    /// Lógica de interacción para Registrar_Recepcionista.xaml
    /// </summary>
    public partial class Registrar_Recepcionista : UserControl
    {
        public Registrar_Recepcionista()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar_Usuario();
            Guardar_Recepcionista();
        }
        public void Guardar_Recepcionista()
        {
            Recepcionista recepcionista = new Recepcionista();
            recepcionista.usuario = new Usuarios();

            recepcionista.documento = txt_Numero_documento.Text;
            recepcionista.tipo_documento = cmb_Tipo_documento.Text;
            recepcionista.nombre = txt_Nombre.Text;
            recepcionista.apellido = txt_Apellido.Text;
            recepcionista.sexo = cmb_Sexo.Text;
            recepcionista.Fecha_nacimiento = dtp_Fecha.SelectedDate.Value;
            recepcionista.fecha_contrato = dtp_Fecha_contrato.SelectedDate.Value;
            recepcionista.telefono = txt_Telefono.Text;
            recepcionista.usuario.Nombre = txt_Usuario.Text;
            try
            {
                Servicio_Recepcionista servicio_recepcionista = new Servicio_Recepcionista();
                string respuesta = servicio_recepcionista.Guardar_Recepcionista(recepcionista);
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
