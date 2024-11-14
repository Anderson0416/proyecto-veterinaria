using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Historial_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Historial(Historial historial)
        {
            MySqlConnection conectar = conexion.crearConexion();
            int historialId;
            conectar.Open();
            string sql = @"INSERT INTO Historial (Mascota_Id) VALUES (@Mascota_Id); SELECT LAST_INSERT_ID();";

            using (MySqlCommand insertHistorialesCommand = new MySqlCommand(sql, conectar))
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conectar))
                {

                    comando.Parameters.AddWithValue("@Mascota_Id", historial.mascota.id);
                    historialId = Convert.ToInt32(comando.ExecuteScalar());
                }
                conectar.Close();
                return historialId;
            }
        }
        public List<Historial> Consultar_Historiales()
        {
            List<Historial> historiales = new List<Historial>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = @"SELECT h.Id AS HistorialId, h.Mascota_Id, h.created_at, 
                          m.id AS MascotaId, m.nombre AS MascotaNombre, 
                          m.especie AS MascotaEspecie, m.raza AS MascotaRaza, 
                          m.sexo AS MascotaSexo, m.edad AS MascotaEdad, m.edad2 AS MascotaEdad2,
                          a.Id AS AnamnesisId, a.Peso, a.Peso2, a.Estado_Reproductivo, 
                          a.Tipo_Vivienda, a.Actividad_Fisica, a.Vacunas_Previas, 
                          a.Vacunas_Previas_Desparasitacion, a.Motivo_Consulta, 
                          a.Sintomas_Mascota, a.Observacione, a.Dieta_Alimentacion
                   FROM Historial h
                   JOIN Mascotas m ON h.Mascota_Id = m.id
                   LEFT JOIN Anamnesis a ON a.Id_Historial = h.Id";

            using (MySqlCommand comando = new MySqlCommand(sql, conectar))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Historial historial = new Historial
                        {
                            id = reader.GetInt32("HistorialId"),
                            fecha = reader.GetDateTime("created_at"),
                            mascota = new Mascota
                            {
                                id = reader.GetInt32("MascotaId"),
                                nombre = reader.GetString("MascotaNombre"),
                                especie = reader.GetString("MascotaEspecie"),
                                raza = reader.GetString("MascotaRaza"),
                                sexo = reader.GetString("MascotaSexo"),
                                edad = reader.GetString("MascotaEdad"),
                                edad2 = reader.GetString("MascotaEdad2")
                            },
                            anamnesis = new Anamnesis
                            {
                                id = reader.IsDBNull(reader.GetOrdinal("AnamnesisId")) ? 0 : reader.GetInt32("AnamnesisId"),
                                peso = reader.IsDBNull(reader.GetOrdinal("Peso")) ? 0 : reader.GetInt32("Peso"),
                                peso2 = reader.IsDBNull(reader.GetOrdinal("Peso2")) ? null : reader.GetString("Peso2"),
                                estado_reproductivo = reader.IsDBNull(reader.GetOrdinal("Estado_Reproductivo")) ? null : reader.GetString("Estado_Reproductivo"),
                                tipo_vivienda = reader.IsDBNull(reader.GetOrdinal("Tipo_Vivienda")) ? null : reader.GetString("Tipo_Vivienda"),
                                actividad_fisica = reader.IsDBNull(reader.GetOrdinal("Actividad_Fisica")) ? null : reader.GetString("Actividad_Fisica"),
                                vacunas_previas = reader.IsDBNull(reader.GetOrdinal("Vacunas_Previas")) ? null : reader.GetString("Vacunas_Previas"),
                                vacunas_precias_desparecitacion = reader.IsDBNull(reader.GetOrdinal("Vacunas_Previas_Desparasitacion")) ? null : reader.GetString("Vacunas_Previas_Desparasitacion"),
                                motivo_consulta = reader.IsDBNull(reader.GetOrdinal("Motivo_Consulta")) ? null : reader.GetString("Motivo_Consulta"),
                                sintomas_mascota = reader.IsDBNull(reader.GetOrdinal("Sintomas_Mascota")) ? null : reader.GetString("Sintomas_Mascota"),
                                observaciones = reader.IsDBNull(reader.GetOrdinal("Observacione")) ? null : reader.GetString("Observacione"),
                                dieta = reader.IsDBNull(reader.GetOrdinal("Dieta_Alimentacion")) ? null : reader.GetString("Dieta_Alimentacion")
                            }
                        };

                        historiales.Add(historial);
                    }
                }
            }

            conectar.Close();
            return historiales;
        }



    }
}
