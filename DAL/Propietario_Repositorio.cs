using Entity;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Propietario_Repositorio
    {
        Conexion conexion = new Conexion();

        public int Registrar_Propietario(Propietario propietario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Propietarios ( Nombre, Apellido, Tipo_Documento, Documento, Sexo, Fecha_Nacimiento, Telefono, gmail )" +
                         "VALUES ( @Nombre, @Apellido, @Tipo_Documento, @Documento, @Sexo, @Fecha_Nacimiento, @Telefono, @gmail)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", propietario.nombre);
            comando.Parameters.AddWithValue("@Apellido", propietario.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", propietario.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", propietario.documento);
            comando.Parameters.AddWithValue("@Sexo", propietario.sexo);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", propietario.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Telefono", propietario.telefono);
            comando.Parameters.AddWithValue("@gmail", propietario.correo);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }

        public bool Existencia_Propietario(string documento)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM Propietarios where Documento like @Documento";

            MySqlCommand comando = new MySqlCommand(sql, conectar); ;
            comando.Parameters.AddWithValue("@Documento", documento);

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

        public List<Propietario> Consultar_Todos_Propietarios()
        {
            List<Propietario> propietarios = new List<Propietario>();


            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Apellido, Tipo_Documento, Documento, Sexo, Fecha_Nacimiento," +
                " Telefono, gmail FROM Propietarios";

            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Propietario propietario = new Propietario();
                        propietario.id = reader.GetInt32("Id");
                        propietario.nombre = reader.GetString("Nombre");
                        propietario.apellido = reader.GetString("Apellido");
                        propietario.tipo_documento = reader.GetString("Tipo_Documento");
                        propietario.documento = reader.GetString("Documento");
                        propietario.sexo = reader.GetString("Sexo");
                        propietario.Fecha_nacimiento = reader.GetDateTime("Fecha_Nacimiento");
                        propietario.telefono = reader.GetString("Telefono");
                        propietario.correo = reader.GetString("gmail");
                        propietarios.Add(propietario);
                    }

                }
            }
            conectar.Close();
            return propietarios;
        }

        public void Eliminar_Propietario(string documento)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Propietarios WHERE (Documento) = @Documento";

            MySqlCommand comando = new MySqlCommand(sql, conectar);


            comando.Parameters.AddWithValue("@Documento", documento);

            int resultado = comando.ExecuteNonQuery();
        }

        public void Actualizar_Propietario(Propietario propietario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Propietarios SET Nombre = @Nombre, Apellido = @Apellido, Tipo_Documento = @Tipo_Documento, " +
                 "Documento = @Documento, Sexo = @Sexo, Fecha_Nacimiento = @Fecha_Nacimiento, Telefono = @Telefono, gmail = @gmail " +
                 "WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", propietario.id);
            comando.Parameters.AddWithValue("@Nombre", propietario.nombre);
            comando.Parameters.AddWithValue("@Apellido", propietario.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", propietario.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", propietario.documento);
            comando.Parameters.AddWithValue("@Sexo", propietario.sexo);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", propietario.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Telefono", propietario.telefono);
            comando.Parameters.AddWithValue("@gmail", propietario.correo);
            int resultado = comando.ExecuteNonQuery();
        }

    }
}
