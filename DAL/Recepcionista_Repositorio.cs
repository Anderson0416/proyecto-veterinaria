using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Recepcionista_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Recepcionista(Recepcionista recepcionista)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Recepcionistas ( Nombre, Apellido, Tipo_Documento, Documento, Sexo, Fecha_Nacimiento, Telefono, Fecha_Contrato, nombre_usuario )" +
                         "VALUES ( @Nombre, @Apellido, @Tipo_Documento, @Documento, @Sexo, @Fecha_Nacimiento, @Telefono, @Fecha_Contrato, @nombre_usuario)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", recepcionista.nombre);
            comando.Parameters.AddWithValue("@Apellido", recepcionista.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", recepcionista.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", recepcionista.documento);
            comando.Parameters.AddWithValue("@Sexo", recepcionista.sexo);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", recepcionista.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Telefono", recepcionista.telefono);
            comando.Parameters.AddWithValue("@Fecha_Contrato", recepcionista.fecha_contrato);
            comando.Parameters.AddWithValue("@nombre_usuario", recepcionista.usuario.Nombre);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public bool Existencia_Recepcionista(string documento)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM Recepcionistas where Documento like @Documento";

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
        public List<Recepcionista> Obtener_Recepcionista()
        {
            List<Recepcionista> recepcionistas = new List<Recepcionista>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Apellido, Tipo_Documento, Documento, Sexo, Telefono," +
                " Fecha_Nacimiento, Fecha_Contrato FROM Recepcionistas";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Recepcionista recepcionista = new Recepcionista();
                        recepcionista.id = reader.GetInt32("Id");
                        recepcionista.nombre = reader.GetString("Nombre");
                        recepcionista.apellido = reader.GetString("Apellido");
                        recepcionista.tipo_documento = reader.GetString("Tipo_Documento");
                        recepcionista.documento = reader.GetString("Documento");
                        recepcionista.sexo = reader.GetString("Sexo");
                        recepcionista.telefono = reader.GetString("Telefono");
                        recepcionista.Fecha_nacimiento = reader.GetDateTime("Fecha_Nacimiento");
                        recepcionista.fecha_contrato = reader.GetDateTime("Fecha_Contrato");

                        recepcionistas.Add(recepcionista);
                    }
                }
            }
            conectar.Close();
            return recepcionistas;
        }
        public void Eliminar_Recepcionista(string documento)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Recepcionistas WHERE (Documento) = @Documento";

            MySqlCommand comando = new MySqlCommand(sql, conectar);


            comando.Parameters.AddWithValue("@Documento", documento);

            int resultado = comando.ExecuteNonQuery();
        }
        public void Actualizar_Recepcionista(Recepcionista recepcionista)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Recepcionistas SET Nombre = @Nombre, Apellido = @Apellido, Tipo_Documento = @Tipo_Documento" +
                ", Documento = @Documento, Sexo = @Sexo, Telefono = @Telefono, Fecha_Nacimiento = @Fecha_Nacimiento," +
                " Fecha_Contrato = @Fecha_Contrato  WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", recepcionista.id);
            comando.Parameters.AddWithValue("@Nombre", recepcionista.nombre);
            comando.Parameters.AddWithValue("@Apellido", recepcionista.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", recepcionista.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", recepcionista.documento);
            comando.Parameters.AddWithValue("@Sexo", recepcionista.sexo);
            comando.Parameters.AddWithValue("@Telefono", recepcionista.telefono);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", recepcionista.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Fecha_Contrato", recepcionista.fecha_contrato);
            int resultado = comando.ExecuteNonQuery();
        }
    }
}
