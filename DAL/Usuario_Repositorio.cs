using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Usuario(Usuarios usuario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO usuario ( Nombre, Contrasena, Id_Tipo)" +
                         "VALUES ( @Nombre, @Contraseña, @Id_Tipo)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            comando.Parameters.AddWithValue("@Id_Tipo", usuario.Tipo_usuario);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public bool Existecia_Usuario(string nombre)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM Usuario where Nombre like @Nombre";

            MySqlCommand comando = new MySqlCommand(sql, conectar); ;
            comando.Parameters.AddWithValue("@Nombre", nombre);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Usuarios ConsultaUsuario(string Nombre)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT Id, Contrasena, Nombre, Id_Tipo FROM Usuario where Nombre like @Nombre";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", Nombre);

            reader = comando.ExecuteReader();

            Usuarios usuarios = null;
            while (reader.Read())
            {
                usuarios = new Usuarios();
                usuarios.id = int.Parse(reader["Id"].ToString());
                usuarios.Nombre = reader["Nombre"].ToString();
                usuarios.Contraseña = reader["Contrasena"].ToString();
                usuarios.Tipo_usuario = int.Parse(reader["Id_Tipo"].ToString());
            }
            return usuarios;
        }
        public List<Tipo_Usuario> Obtener_Tipo_Usuarios()
        {
            List<Tipo_Usuario> usuarios = new List<Tipo_Usuario>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre" +
                " FROM Tipo_Usuario";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tipo_Usuario tipo_usuario = new Tipo_Usuario();
                        tipo_usuario.id = reader.GetInt32("Id");
                        tipo_usuario.nombre = reader.GetString("Nombre");
                        usuarios.Add(tipo_usuario);
                    }
                }
            }
            conectar.Close();
            return usuarios;
        }
    }
}
