using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BLL
{
    public class Servicio_Login
    {
        public string control_Login(Usuarios usuario)
        {
            Usuario_Repositorio usuario_repositorio = new Usuario_Repositorio();

            string respuesta = "";
            Usuarios Datousuario = new Usuarios();

            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Contraseña))
            {
                respuesta = "DEBE LLENAR TODOS LOS DATOS";
            }
            else
            {
                Datousuario = usuario_repositorio.ConsultaUsuario(usuario.Nombre);

                if (Datousuario == null)
                {
                    respuesta = "EL USUARIO NO EXISTE";
                }
                else
                {
                    if (Datousuario.Contraseña != generarSHA1(usuario.Contraseña))
                    {
                        respuesta = "EL USUARIO O LA CONTRASEÑA NO COINCIDEN";
                    }
                    else
                    {

                        Seccion.id = Datousuario.id;
                        Seccion.Nombre = Datousuario.Nombre;
                        Seccion.Tipo_usuario = Datousuario.Tipo_usuario;
                        consultar_Veterinario(usuario);
                    }
                }
            }
            return respuesta;
        }

        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append('0');
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }

        private void consultar_Veterinario(Usuarios usuario)
        {
            Servicio_Veterinario servicio_veterinario =  new Servicio_Veterinario();
            List<Veterinario> veterinarios = servicio_veterinario.Lista_Todos_Veterinario();
            Veterinario veterinario = veterinarios.FirstOrDefault(v => v.usuario != null && v.usuario.Nombre == usuario.Nombre);
            if (veterinario != null)
            {
                Seccion.AsignarVeterinario(veterinario);
            }
        }
    }
}
