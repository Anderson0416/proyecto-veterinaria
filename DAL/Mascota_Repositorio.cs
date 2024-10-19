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
    public class Mascota_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Mascota(Mascota mascota)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            {
                string sql = "INSERT INTO Mascotas (Nombre, Especie, Raza, Sexo, Edad, Edad2, Propietario_Documento) " +
                             "VALUES (@Nombre, @Especie, @Raza, @Sexo, @Edad, @Edad2, @Propietario_Documento)";
                MySqlCommand comando = new MySqlCommand(sql, conectar);

                comando.Parameters.AddWithValue("@Nombre", mascota.nombre);
                comando.Parameters.AddWithValue("@Especie", mascota.especie);
                comando.Parameters.AddWithValue("@Raza", mascota.raza);
                comando.Parameters.AddWithValue("@Sexo", mascota.sexo);
                comando.Parameters.AddWithValue("@Edad", mascota.edad);
                comando.Parameters.AddWithValue("@Edad2", mascota.edad2);
                comando.Parameters.AddWithValue("@Propietario_Documento", mascota.propietario.documento);

                int resultado = comando.ExecuteNonQuery();

                return resultado;
            }
        }

        public List<Mascota> Consulta_Mascota_Cliente(string documento)
        {
            List<Mascota> mascotas = new List<Mascota>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Especie, Raza, Sexo, Edad, Edad2, Propietario_Documento " +
                         "FROM Mascotas WHERE Propietario_Documento = @Propietario_Documento";

            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@Propietario_Documento", documento);

                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Mascota mascota = new Mascota();
                        mascota.propietario = new Propietario();
                        mascota.id = reader.GetInt32("Id");
                        mascota.nombre = reader.GetString("Nombre");
                        mascota.especie = reader.GetString("Especie");
                        mascota.raza = reader.GetString("Raza");
                        mascota.sexo = reader.GetString("Sexo");
                        mascota.edad = reader.GetString("Edad");
                        mascota.edad2 = reader.GetString("Edad2");
                        mascota.propietario.documento = reader.GetString("Propietario_Documento");
                        mascotas.Add(mascota);

                    }
                }
            }

            conectar.Close();
            return mascotas;
        }

        public Mascota Consulta_Mascota_Id(int idMascota)
        {
            Mascota mascota = null;

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Especie, Raza, Sexo, Edad, Edad2 " +
                         "FROM Mascotas WHERE Id = @IdMascota"; 

            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@IdMascota", idMascota);

                using (reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mascota = new Mascota
                        {
                            id = reader.GetInt32("Id"),
                            nombre = reader.GetString("Nombre"),
                            especie = reader.GetString("Especie"),
                            raza = reader.GetString("Raza"),
                            sexo = reader.GetString("Sexo"),
                            edad = reader.GetString("Edad"),
                            edad2 = reader.GetString("Edad2"),
                        };
                    }
                }
            }

            conectar.Close();
            return mascota;
        }

        public List<Mascota> Consultar_Todos_Mascota()
        {
            List<Mascota> mascotas = new List<Mascota>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Especie, Raza, Sexo, Edad, Edad2," +
                " Propietario_Documento FROM Mascotas";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mascota mascota = new Mascota();
                        Propietario propietario = new Propietario();

                        mascota.id = reader.GetInt32("Id");
                        mascota.nombre = reader.GetString("Nombre");
                        mascota.especie = reader.GetString("Especie");
                        mascota.raza = reader.GetString("Raza");
                        mascota.sexo = reader.GetString("Sexo");
                        mascota.edad = reader.GetString("Edad");
                        mascota.edad2 = reader.GetString("Edad2");
                        propietario.documento = reader.GetString("Propietario_Documento");
                        mascota.propietario = propietario;
                        mascotas.Add(mascota);

                    }
                }
            }
            conectar.Close();
            return mascotas;
        }

        public void Eliminar_Mascota(int Id)
        {

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM mascotas WHERE (Id) = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);


            comando.Parameters.AddWithValue("@Id", Id);

            int resultado = comando.ExecuteNonQuery();
        }

        public void Actualizar_Mascota(Mascota mascota)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Mascotas SET Nombre = @Nombre, Especie = @Especie, Raza = @Raza, Sexo = @Sexo, Edad = @Edad, " +
             "Edad2 = @Edad2, Propietario_Documento = @Propietario_Documento WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", mascota.id);
            comando.Parameters.AddWithValue("@Nombre", mascota.nombre);
            comando.Parameters.AddWithValue("@Especie", mascota.especie);
            comando.Parameters.AddWithValue("@Raza", mascota.raza);
            comando.Parameters.AddWithValue("@Sexo", mascota.sexo);
            comando.Parameters.AddWithValue("@Edad", mascota.edad);
            comando.Parameters.AddWithValue("@Edad2", mascota.edad2);
            comando.Parameters.AddWithValue("@Propietario_Documento", mascota.propietario.documento);
            int resultado = comando.ExecuteNonQuery();
        }
    }
}
