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
    }
}
