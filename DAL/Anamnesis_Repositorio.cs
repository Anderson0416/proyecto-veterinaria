using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Anamnesis_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Anamnesis(Anamnesis anamnesis)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Anamnesis ( Peso, peso2, Estado_Reproductivo, Tipo_Vivienda, Actividad_Fisica," +
                " Vacunas_Previas, Vacunas_Previas_Desparasitacion, Motivo_Consulta, Sintomas_Mascota," +
                " Observacione, Dieta_Alimentacion, Id_Historial )" +
                "VALUES ( @Peso, @peso2, @Estado_Reproductivo, @Tipo_Vivienda, @Actividad_Fisica," +
                " @Vacunas_Previas, @Vacunas_Previas_Desparasitacion, @Motivo_Consulta, @Sintomas_Mascota," +
                " @Observacione, @Dieta_Alimentacion, @Id_Historial  )";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Peso", anamnesis.peso);
            comando.Parameters.AddWithValue("@peso2", anamnesis.peso2);
            comando.Parameters.AddWithValue("@Estado_Reproductivo", anamnesis.estado_reproductivo);
            comando.Parameters.AddWithValue("@Tipo_Vivienda", anamnesis.tipo_vivienda);
            comando.Parameters.AddWithValue("@Actividad_Fisica", anamnesis.actividad_fisica);
            comando.Parameters.AddWithValue("@Vacunas_Previas", anamnesis.vacunas_previas);
            comando.Parameters.AddWithValue("@Vacunas_Previas_Desparasitacion", anamnesis.vacunas_precias_desparecitacion);
            comando.Parameters.AddWithValue("@Motivo_Consulta", anamnesis.motivo_consulta);
            comando.Parameters.AddWithValue("@Sintomas_Mascota", anamnesis.sintomas_mascota);
            comando.Parameters.AddWithValue("@Observacione", anamnesis.observaciones);
            comando.Parameters.AddWithValue("@Dieta_Alimentacion", anamnesis.dieta);
            comando.Parameters.AddWithValue("@Id_Historial", anamnesis.historal.id);

            int resultado = comando.ExecuteNonQuery();

            conectar.Close();

            return resultado;
        }
        public List<Anamnesis> Consultar_Anamnesis()
        {
            List<Anamnesis> anamnesisList = new List<Anamnesis>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = @"SELECT a.Id, a.Peso, a.peso2, a.Estado_Reproductivo, a.Tipo_Vivienda, a.Actividad_Fisica,
                            a.Vacunas_Previas, a.Vacunas_Previas_Desparasitacion, a.Motivo_Consulta, a.Sintomas_Mascota,
                            a.Observacione, a.Dieta_Alimentacion, a.Id_Historial,
                            h.Mascota_Id, h.id AS HistorialId,
                            m.nombre AS MascotaNombre, m.especie AS MascotaEspecie, m.raza AS MascotaRaza,
                            m.sexo AS MascotaSexo, m.edad AS MascotaEdad, m.edad2 AS MascotaEdad2
                            FROM Anamnesis a
                            INNER JOIN Historial h ON a.Id_Historial = h.id
                            INNER JOIN Mascotas m ON h.Mascota_Id = m.id";

            using (MySqlCommand comando = new MySqlCommand(sql, conectar))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Anamnesis anamnesis = new Anamnesis
                        {
                            id = reader.GetInt32("Id"),
                            peso = reader.GetInt32("Peso"),
                            peso2 = reader.GetString("peso2"),
                            estado_reproductivo = reader.GetString("Estado_Reproductivo"),
                            tipo_vivienda = reader.GetString("Tipo_Vivienda"),
                            actividad_fisica = reader.GetString("Actividad_Fisica"),
                            vacunas_previas = reader.GetString("Vacunas_Previas"),
                            vacunas_precias_desparecitacion = reader.GetString("Vacunas_Previas_Desparasitacion"),
                            motivo_consulta = reader.GetString("Motivo_Consulta"),
                            sintomas_mascota = reader.GetString("Sintomas_Mascota"),
                            observaciones = reader.GetString("Observacione"),
                            dieta = reader.GetString("Dieta_Alimentacion"),
                            historal = new Historial
                            {
                                id = reader.GetInt32("HistorialId"),
                                mascota = new Mascota
                                {
                                    id = reader.GetInt32("Mascota_Id"),
                                    nombre = reader.GetString("MascotaNombre"),
                                    especie = reader.GetString("MascotaEspecie"),
                                    raza = reader.GetString("MascotaRaza"),
                                    sexo = reader.GetString("MascotaSexo"),
                                    edad = reader.GetString("MascotaEdad"),
                                    edad2 = reader.GetString("MascotaEdad2")
                                },
                            }
                        };

                        anamnesisList.Add(anamnesis);
                    }
                }
            }

            conectar.Close();

            return anamnesisList;
        }
    }
}
