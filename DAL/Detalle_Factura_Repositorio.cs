using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Detalle_Factura_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Detalle_Factura(Detalles_Factura detalles_factura)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO DetallesFactura ( Id_Factura, Id_Producto, Cantidad, Subtotal )" +
                         "VALUES ( @Id_Factura, @Id_Producto, @Cantidad, @Subtotal )";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id_Factura", detalles_factura.factura.id);
            comando.Parameters.AddWithValue("@Id_Producto", detalles_factura.producto.id);
            comando.Parameters.AddWithValue("@Cantidad", detalles_factura.cantidad);
            comando.Parameters.AddWithValue("@Subtotal", detalles_factura.sub_total);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
        public List<Detalles_Factura> Obtener_Detalle_Facturas()
        {
            List<Detalles_Factura> detalle_facturas = new List<Detalles_Factura>();
            using (MySqlConnection conectar = conexion.crearConexion())
            {
                conectar.Open();
                string query = @"SELECT 
                df.Id AS Id, df.Cantidad, df.Subtotal, 
                p.Id AS Id, p.Nombre AS ProductoNombre, p.Precio AS ProductoPrecio, p.Stock AS ProductoStock,
                f.Id, f.Fecha, f.Total
                FROM DetallesFactura df
                INNER JOIN Productos p ON df.Id_Producto = p.Id
                INNER JOIN Facturas f ON df.Id_Factura = f.Id";
                using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Detalles_Factura detalle = new Detalles_Factura
                            {
                                id = reader.GetInt32("Id"),
                                cantidad = reader.GetInt32("Cantidad"),
                                sub_total = reader.GetDecimal("Subtotal"),
                                producto = new Producto
                                {
                                    id = reader.GetInt32("Id"),
                                    nombre = reader.GetString("ProductoNombre"),
                                    precio = reader.GetDecimal("ProductoPrecio"),
                                    stock = reader.GetInt32("ProductoStock")
                                },
                                factura = new Factura
                                {
                                    id = reader.GetInt32("Id"),
                                    fecha = reader.GetDateTime("Fecha"),
                                    total = reader.GetDecimal("Total"),
                                }
                            };
                            detalle_facturas.Add(detalle);
                        }
                    }
                }
            }
            return detalle_facturas;
        }
    }
}
