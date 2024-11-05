using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tipo_Consulta_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Tipo_Consulta(Tipo_Consulta tipo_Consulta)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Tipos_Consultas ( Nombre, Descripcion, Precio)" +
                         "VALUES ( @Nombre, @Descripcion, @Precio)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", tipo_Consulta.nombre);
            comando.Parameters.AddWithValue("@Descripcion", tipo_Consulta.descripcion);
            comando.Parameters.AddWithValue("@Precio", tipo_Consulta.precio);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public bool Existecia_Tipo_Consulta(string nombre)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM Tipos_Consultas where Nombre like @Nombre";

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
        public List<Tipo_Consulta> Obtener_Tipo_Consulta()
        {
            List<Tipo_Consulta> tipo_Consultas = new List<Tipo_Consulta>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, Descripcion, Precio FROM Tipos_Consultas";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tipo_Consulta tipo_Consulta = new Tipo_Consulta();
                        tipo_Consulta.id = reader.GetInt32("Id");
                        tipo_Consulta.nombre = reader.GetString("Nombre");
                        tipo_Consulta.descripcion = reader.GetString("Descripcion");
                        tipo_Consulta.precio = reader.GetDecimal(reader.GetOrdinal("precio"));


                        tipo_Consultas.Add(tipo_Consulta);
                    }
                }
            }
            conectar.Close();
            return tipo_Consultas;
        }
        public void Eliminar_Tipo_Consulta(int id)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Tipos_Consultas WHERE (Id) = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);


            comando.Parameters.AddWithValue("@Id", id);

            int resultado = comando.ExecuteNonQuery();

        }
        public int Actualizar_Tipo_Consulta(Tipo_Consulta tipo_Consulta)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "UPDATE Tipos_Consultas SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", tipo_Consulta.id);
            comando.Parameters.AddWithValue("@Nombre", tipo_Consulta.nombre);
            comando.Parameters.AddWithValue("@Descripcion", tipo_Consulta.descripcion);
            comando.Parameters.AddWithValue("@Precio", tipo_Consulta.precio);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
    }
}
