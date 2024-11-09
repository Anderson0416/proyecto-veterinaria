using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Veterinario_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Veterinario(Veterinario veterinario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Veterinarios ( Nombre, Apellido, Tipo_Documento, Documento, Sexo, Fecha_Nacimiento, Telefono, Fecha_Contrato, nombre_usuario )" +
                         "VALUES ( @Nombre, @Apellido, @Tipo_Documento, @Documento, @Sexo, @Fecha_Nacimiento, @Telefono, @Fecha_Contrato, @nombre_usuario)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", veterinario.nombre);
            comando.Parameters.AddWithValue("@Apellido", veterinario.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", veterinario.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", veterinario.documento);
            comando.Parameters.AddWithValue("@Sexo", veterinario.sexo);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", veterinario.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Telefono", veterinario.telefono);
            comando.Parameters.AddWithValue("@Fecha_Contrato", veterinario.fecha_contrato);
            comando.Parameters.AddWithValue("@nombre_usuario", veterinario.usuario.Nombre);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public bool Existencia_Veterinario(string documento)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM Veterinarios where Documento like @Documento";

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
        public List<Veterinario> ObtenerVeterinarios()
        {
            List<Veterinario> veterinarios = new List<Veterinario>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Apellido, Tipo_Documento, Documento, Sexo, Telefono," +
                " Fecha_Nacimiento, Fecha_Contrato FROM Veterinarios";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Veterinario veterinario = new Veterinario();
                        veterinario.id = reader.GetInt32("Id");
                        veterinario.nombre = reader.GetString("Nombre");
                        veterinario.apellido = reader.GetString("Apellido");
                        veterinario.tipo_documento = reader.GetString("Tipo_Documento");
                        veterinario.documento = reader.GetString("Documento");
                        veterinario.sexo = reader.GetString("Sexo");
                        veterinario.telefono = reader.GetString("Telefono");
                        veterinario.Fecha_nacimiento = reader.GetDateTime("Fecha_Nacimiento");
                        veterinario.fecha_contrato = reader.GetDateTime("Fecha_Contrato");

                        veterinarios.Add(veterinario);
                    }
                }
            }
            conectar.Close();
            return veterinarios;
        }
        public Veterinario Consulta_Documento_Veterinario(string documento)
        {
            Veterinario veterinario = new Veterinario();
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT Nombre, Apellido, Tipo_Documento, Documento, Sexo, Fecha_Nacimiento, Fecha_Contrato " +
             "FROM Veterinarios WHERE Documento LIKE @Documento";

            MySqlCommand comando = new MySqlCommand(sql, conectar);
            comando.Parameters.AddWithValue("@Documento", documento);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    veterinario.nombre = reader.GetString(0);
                    veterinario.apellido = reader.GetString(1);
                    veterinario.tipo_documento = reader.GetString(2);
                    veterinario.documento = reader.GetString(3);
                    veterinario.sexo = reader.GetString(4);
                    veterinario.Fecha_nacimiento = reader.GetDateTime(5);
                    veterinario.fecha_contrato = reader.GetDateTime(6);
                }
            }
            return veterinario;
        }
        public string Eliminar_Veterinario(string documento)
        {
            MySqlConnection conectar = conexion.crearConexion();
            string respuesta;

            try
            {
                conectar.Open();

                string sql = "DELETE FROM veterinarios WHERE Documento = @Documento";
                MySqlCommand comando = new MySqlCommand(sql, conectar);
                comando.Parameters.AddWithValue("@Documento", documento);

                int resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    respuesta = "El veterinario ha sido eliminado exitosamente.";
                }
                else
                {
                    respuesta = "No se encontró un veterinario con el documento especificado.";
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                respuesta = "El veterinario no se puede eliminar porque tiene citas programadas.";
            }
            catch (Exception ex)
            {
                respuesta = $"Ocurrió un error al intentar eliminar el veterinario: {ex.Message}";
            }
            finally
            {
                conectar.Close();
            }
            return respuesta;
        }
        public void Actualizar_Veterinario(Veterinario veterinario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Veterinarios SET Nombre = @Nombre, Apellido = @Apellido, Tipo_Documento = @Tipo_Documento" +
                ", Documento = @Documento, Sexo = @Sexo, Telefono = @Telefono, Fecha_Nacimiento = @Fecha_Nacimiento," +
                " Fecha_Contrato = @Fecha_Contrato  WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", veterinario.id);
            comando.Parameters.AddWithValue("@Nombre", veterinario.nombre);
            comando.Parameters.AddWithValue("@Apellido", veterinario.apellido);
            comando.Parameters.AddWithValue("@Tipo_Documento", veterinario.tipo_documento);
            comando.Parameters.AddWithValue("@Documento", veterinario.documento);
            comando.Parameters.AddWithValue("@Sexo", veterinario.sexo);
            comando.Parameters.AddWithValue("@Telefono", veterinario.telefono);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", veterinario.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@Fecha_Contrato", veterinario.fecha_contrato);

            int resultado = comando.ExecuteNonQuery();

            if (resultado > 0)
            {
                Console.WriteLine("Veterinario actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el Veterinario con el ID especificado.");
            }
        }
    }
}
