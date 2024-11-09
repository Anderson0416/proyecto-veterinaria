using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cita_Tipo_Consulta_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Cita_Tipo_Consulta(Cita_Tipo_Consulta cita_Tipo_Consulta)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Cita_Tipo_Consulta (Cita_Id, Tipo_Consulta_Id) VALUES (@CitaId, @TipoConsultaId)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@CitaId", cita_Tipo_Consulta.citas.id);
            comando.Parameters.AddWithValue("@TipoConsultaId", cita_Tipo_Consulta.tipo_consulta.id);
            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public List<Cita_Tipo_Consulta> Consultar_Todas_Cita_Tipo_Consulta()
        {
            List<Cita_Tipo_Consulta> citas_consultas = new List<Cita_Tipo_Consulta>();
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT Cita_Tipo_Consulta.Id AS CitaTipoConsultaId, Cita_Tipo_Consulta.Cita_Id, " +
                         "Tipos_Consultas.Id AS TipoConsultaId, Tipos_Consultas.Nombre, " +
                         "Tipos_Consultas.Descripcion, Tipos_Consultas.Precio " +
                         "FROM Cita_Tipo_Consulta " +
                         "JOIN Tipos_Consultas ON Cita_Tipo_Consulta.Tipo_Consulta_Id = Tipos_Consultas.Id;";

            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cita_tipo_consulta = MapearCitaTipoConsulta(reader);
                        cita_tipo_consulta.citas = MapearCitas(reader);
                        cita_tipo_consulta.tipo_consulta = MapearTipoConsulta(reader);

                        citas_consultas.Add(cita_tipo_consulta);
                    }
                }
            }

            conectar.Close();
            return citas_consultas;
        }
        private Cita_Tipo_Consulta MapearCitaTipoConsulta(MySqlDataReader reader)
        {
            return new Cita_Tipo_Consulta
            {
                id = reader.GetInt32("CitaTipoConsultaId")
            };
        }
        private Citas MapearCitas(MySqlDataReader reader)
        {
            return new Citas
            {
                id = reader.GetInt32("Cita_Id")
            };
        }
        private Tipo_Consulta MapearTipoConsulta(MySqlDataReader reader)
        {
            return new Tipo_Consulta
            {
                id = reader.GetInt32("TipoConsultaId"),
                nombre = reader.GetString("Nombre"),
                descripcion = reader.GetString("Descripcion"),
                precio = reader.GetDecimal("Precio")
            };
        }
        public bool Eliminar_Cita_Tipo_Consulta(int id)
        {
            bool eliminado = false;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Cita_Tipo_Consulta WHERE Cita_Id = @Cita_Id";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@Cita_Id", id);

                int resultado = comando.ExecuteNonQuery();
                eliminado = resultado > 0;
            }

            conectar.Close();
            return eliminado;
        }
        public bool Actualizar_Cita_Tipo_Consulta(int citaTipoConsultaId, int nuevoCitaId, int nuevoTipoConsultaId)
        {
            bool actualizado = false;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Cita_Tipo_Consulta SET Cita_Id = @NuevoCitaId, Tipo_Consulta_Id = @NuevoTipoConsultaId" +
                "WHERE Id = @Id";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@Id", citaTipoConsultaId);
                comando.Parameters.AddWithValue("@NuevoCitaId", nuevoCitaId);
                comando.Parameters.AddWithValue("@NuevoTipoConsultaId", nuevoTipoConsultaId);

                int resultado = comando.ExecuteNonQuery();
                actualizado = resultado > 0;
            }

            conectar.Close();
            return actualizado;
        }
    }
}
