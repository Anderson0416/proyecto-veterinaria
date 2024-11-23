using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factura_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Factura(Factura factura)
        {
            int idFactura = 0;

            using (MySqlConnection conectar = conexion.crearConexion())
            {
                conectar.Open();

                string sql = "INSERT INTO Facturas (Total) VALUES (@Total); SELECT LAST_INSERT_ID();";
                using (MySqlCommand comando = new MySqlCommand(sql, conectar))
                {
                    comando.Parameters.AddWithValue("@Total", factura.total);
                    idFactura = Convert.ToInt32(comando.ExecuteScalar());
                }
            }

            return idFactura;
        }
        public List<Factura> Obtener_Facturas()
        {
            List<Factura> facturas = new List<Factura>();
            using (MySqlConnection conectar = conexion.crearConexion())
            {
                conectar.Open();
                string query = @"SELECT Id, Fecha, Total FROM Facturas";
            
                using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factura factura = new Factura
                            {
                                id = reader.GetInt32("Id"),
                                fecha = reader.GetDateTime("Fecha"),
                                total = reader.GetDecimal("Total"),
                            };
                            facturas.Add(factura);
                        }
                    }
                }
            }
            return facturas;
        }
    }
}
