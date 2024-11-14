using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cita_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Cita(Citas cita)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Citas ( Propietario_Id, Mascota_Id, Veterinario_Id, Fecha_cita, Estado_pago, Total_Pagar, Notas )" +
                         "VALUES ( @Propietario_Id, @Mascota_Id, @Veterinario_Id, @Fecha_cita, @Estado_pago, @Total_Pagar, @Notas)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Propietario_Id", cita.propietario.id);
            comando.Parameters.AddWithValue("@Mascota_Id", cita.mascota.id);
            comando.Parameters.AddWithValue("@Veterinario_Id", cita.veterinario.id);
            comando.Parameters.AddWithValue("@Fecha_cita", cita.fecha_cita);
            comando.Parameters.AddWithValue("@Estado_pago", cita.estado);
            comando.Parameters.AddWithValue("@Total_Pagar", cita.total_pagar);
            comando.Parameters.AddWithValue("@Notas", cita.nota);
            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public List<Citas> Consultar_Todas_Citas()
        {
            List<Citas> Citas = new List<Citas>();
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = @"
            SELECT 
                c.Id AS CitaId, c.Fecha_cita, c.Estado_pago, c.Total_Pagar, c.Notas, c.created_at,
                p.Id AS PropietarioId, p.Nombre AS PropietarioNombre, p.Apellido AS PropietarioApellido, p.Tipo_documento AS PropietarioTipoDocumento,
                p.Documento AS PropietarioDocumento, p.Sexo AS PropietarioSexo, p.Telefono AS PropietarioTelefono, p.Fecha_Nacimiento AS PropietarioFechaNacimiento,
                m.Id AS MascotaId, m.Nombre AS MascotaNombre, m.Especie AS MascotaEspecie, m.Raza AS MascotaRaza, m.Sexo AS MascotaSexo, 
                m.Edad AS MascotaEdad, m.Edad2 AS MascotaEdad2, m.Propietario_Documento AS MascotaPropietarioDocumento,
                v.Id AS VeterinarioId, v.Nombre AS VeterinarioNombre, v.Apellido AS VeterinarioApellido, v.Tipo_documento AS VeterinarioTipoDocumento, 
                v.Documento AS VeterinarioDocumento, v.Sexo AS VeterinarioSexo, v.Telefono AS VeterinarioTelefono, v.Fecha_Nacimiento AS VeterinarioFechaNacimiento, 
                v.Fecha_Contrato AS VeterinarioFechaContrato
            FROM 
                Citas c
            JOIN 
                Propietarios p ON c.Propietario_Id = p.Id
            JOIN 
                Mascotas m ON c.Mascota_Id = m.Id
            JOIN 
                Veterinarios v ON c.Veterinario_Id = v.Id;";

            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Citas cita = MapearCita(reader);
                        cita.propietario = MapearPropietario(reader);
                        cita.mascota = MapearMascota(reader);
                        cita.veterinario = MapearVeterinario(reader);

                        Citas.Add(cita);
                    }
                }
            }

            conectar.Close();
            return Citas;
        }
        private Citas MapearCita(MySqlDataReader reader)
        {
            return new Citas
            {
                id = reader.GetInt32("CitaId"),
                fecha_cita = reader.GetDateTime("Fecha_cita"),
                estado = reader.GetString("Estado_pago"),
                total_pagar = reader.GetDecimal("Total_Pagar"),
                nota = reader.IsDBNull(reader.GetOrdinal("Notas")) ? null : reader.GetString("Notas"),
            };
        }
        private Propietario MapearPropietario(MySqlDataReader reader)
        {
            return new Propietario
            {
                id = reader.GetInt32("PropietarioId"),
                nombre = reader.GetString("PropietarioNombre"),
                apellido = reader.GetString("PropietarioApellido"),
                tipo_documento = reader.GetString("PropietarioTipoDocumento"),
                documento = reader.GetString("PropietarioDocumento"),
                sexo = reader.GetString("PropietarioSexo"),
                telefono = reader.GetString("PropietarioTelefono"),
                Fecha_nacimiento = reader.GetDateTime("PropietarioFechaNacimiento")
            };
        }
        private Mascota MapearMascota(MySqlDataReader reader)
        {
            return new Mascota
            {
                id = reader.GetInt32("MascotaId"),
                nombre = reader.GetString("MascotaNombre"),
                especie = reader.GetString("MascotaEspecie"),
                raza = reader.GetString("MascotaRaza"),
                sexo = reader.GetString("MascotaSexo"),
                edad = reader.GetString("MascotaEdad"),
                edad2 = reader.GetString("MascotaEdad2")
            };
        }
        private Veterinario MapearVeterinario(MySqlDataReader reader)
        {
            return new Veterinario
            {
                id = reader.GetInt32("VeterinarioId"),
                nombre = reader.GetString("VeterinarioNombre"),
                apellido = reader.GetString("VeterinarioApellido"),
                tipo_documento = reader.GetString("VeterinarioTipoDocumento"),
                documento = reader.GetString("VeterinarioDocumento"),
                sexo = reader.GetString("VeterinarioSexo"),
                telefono = reader.GetString("VeterinarioTelefono"),
                Fecha_nacimiento = reader.GetDateTime("VeterinarioFechaNacimiento"),
                fecha_contrato = reader.GetDateTime("VeterinarioFechaContrato")
            };
        }
        public int Eliminar_Cita(int Id)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Citas WHERE Id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", Id);
            int resultado = comando.ExecuteNonQuery();

            conectar.Close();
            return resultado;
        }
        public int Actualizar_Cita(Citas cita)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Citas SET Propietario_Id = @Propietario_Id, Mascota_Id = @Mascota_Id, " +
                         "Veterinario_Id = @Veterinario_Id, Fecha_cita = @Fecha_cita, Estado_pago = @Estado_pago, " +
                         "Total_Pagar = @Total_Pagar, Notas = @Notas WHERE Id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", cita.id);
            comando.Parameters.AddWithValue("@Propietario_Id", cita.propietario.id);
            comando.Parameters.AddWithValue("@Mascota_Id", cita.mascota.id);
            comando.Parameters.AddWithValue("@Veterinario_Id", cita.veterinario.id);
            comando.Parameters.AddWithValue("@Fecha_cita", cita.fecha_cita);
            comando.Parameters.AddWithValue("@Estado_pago", cita.estado);
            comando.Parameters.AddWithValue("@Total_Pagar", cita.total_pagar);
            comando.Parameters.AddWithValue("@Notas", cita.nota);

            int resultado = comando.ExecuteNonQuery();

            conectar.Close();
            return resultado;
        }
        public int Actualizar_Estado_Cita(int id, string estado)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Citas SET  Estado_pago = @Estado_pago WHERE Id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Estado_pago", estado);

            int resultado = comando.ExecuteNonQuery();

            conectar.Close();
            return resultado;
        }
        public int Ultima_Cita_Registrada ()
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            string sql = "SELECT MAX(Id) FROM Citas";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            int cita_id = Convert.ToInt32(comando.ExecuteScalar());

            return cita_id;
        }
    }
}
