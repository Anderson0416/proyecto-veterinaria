using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producto_Repositorio
    {
        Conexion conexion = new Conexion();
        public int Registrar_Producto(Producto producto)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO Productos ( Nombre, Descripcion, Precio, Stock )" +
                         "VALUES ( @Nombre, @Descripcion, @Precio, @Stock)";
            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Nombre", producto.nombre);
            comando.Parameters.AddWithValue("@Descripcion", producto.descripcion);
            comando.Parameters.AddWithValue("@Precio", producto.precio);
            comando.Parameters.AddWithValue("@Stock", producto.stock);

            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
        public List<Producto> Consultar_Producto()
        {

            List<Producto> productos = new List<Producto>();

            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            MySqlDataReader reader;

            string sql = "SELECT Id, Nombre, " +
                " Precio, Stock, Descripcion FROM Productos";

            using (var comando = new MySqlCommand(sql, conectar))
            {
                using (reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Producto producto = new Producto();
                        producto.id = reader.GetInt32("Id");
                        producto.nombre = reader.GetString("Nombre");
                        producto.stock = reader.GetInt32("Stock");
                        producto.precio = reader.GetInt32("Precio");
                        producto.descripcion = reader.GetString("Descripcion");
                        productos.Add(producto);

                    }
                }
            }
            conectar.Close();
            return productos;
        }
        public void Eliminar_Producto(int ID)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "DELETE FROM Productos WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);


            comando.Parameters.AddWithValue("@Id", ID);

            int resultado = comando.ExecuteNonQuery();

        }
        public void Actualizar_Producto(Producto producto)
        {
            MySqlConnection conectar = conexion.crearConexion();

            conectar.Open();

            string sql = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, " +
            "Precio = @Precio, Stock = @Stock WHERE Id = @Id";

            MySqlCommand comando = new MySqlCommand(sql, conectar);

            comando.Parameters.AddWithValue("@Id", producto.id);
            comando.Parameters.AddWithValue("@Nombre", producto.nombre);
            comando.Parameters.AddWithValue("@Descripcion", producto.descripcion);
            comando.Parameters.AddWithValue("@Precio", producto.precio);
            comando.Parameters.AddWithValue("@Stock", producto.stock);

            int resultado = comando.ExecuteNonQuery();
        }





        public void Actualizar_Cantidad_Resta_Producto(Producto producto)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            string sql = "UPDATE Productos SET Cantidad = Cantidad - @cantidadComprada WHERE Id = @id";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@cantidadComprada", producto.stock);
                comando.Parameters.AddWithValue("@id", producto.id);
                comando.ExecuteNonQuery();
            }

        }
        public void Actualizar_Cantidad_Suma_Producto(Producto producto)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();
            string sql = "UPDATE Productos SET Cantidad = Cantidad + @cantidadComprada WHERE Id = @id";
            using (var comando = new MySqlCommand(sql, conectar))
            {
                comando.Parameters.AddWithValue("@cantidadComprada", producto.stock);
                comando.Parameters.AddWithValue("@id", producto.id);
                comando.ExecuteNonQuery();
            }

        }
    }
}
