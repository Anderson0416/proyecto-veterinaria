using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Usuarios
    {
        public string Validacion_Usuario(Usuarios usuario)
        {
            Usuario_Repositorio usuario_repositorio = new Usuario_Repositorio();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Contraseña) ||
                string.IsNullOrEmpty(usuario.Confirmar_Contraseña) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "DEBE LLENAR TODOS LOS DATOS";
            }
            else
            {
                if (usuario.Contraseña == usuario.Confirmar_Contraseña)
                {
                    if (usuario_repositorio.Existecia_Usuario(usuario.Nombre))
                    {
                        respuesta = "EL USUARIO YA EXISTE";
                    }
                    else
                    {
                        usuario.Contraseña = generarSHA1(usuario.Contraseña);
                        usuario_repositorio.Registrar_Usuario(usuario);
                    }
                }
                else
                {
                    respuesta = "LAS CONTRASEÑAS NO COINCIDE";
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
        public List<Tipo_Usuario> Lista_Cargo()
        {
            Usuario_Repositorio usuario_repositorio = new Usuario_Repositorio();
            List<Tipo_Usuario> tipo_usuarios;
            tipo_usuarios = usuario_repositorio.Obtener_Tipo_Usuarios();
            return tipo_usuarios;
            
        }
    }
}
