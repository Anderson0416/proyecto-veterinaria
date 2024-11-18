using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Producto
    {
        public string Registrar_Producto(Producto producto)
        {
            Producto_Repositorio producto_repositorio = new Producto_Repositorio();

            string respuesta = Validar_Campos(producto);
            if (respuesta != null)
            {
              return respuesta;
            }
            respuesta = Validar_Existencia(producto);
            if (respuesta != null)
            {
                return respuesta;
            }
            producto_repositorio.Registrar_Producto(producto);
            return "PRODUCTO REGISTRADO";
        }
        private string Validar_Campos(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.descripcion) || string.IsNullOrEmpty(producto.nombre) ||
                producto.precio < 0)
            {
                return "DEBE LLENAR TODOS LOS DATOS";
            }
            return null;
        }
        private string Validar_Existencia(Producto producto)
        {
            List<Producto> lista_Productos = Lista_Productos();

            var producto_Existente = lista_Productos
                .FirstOrDefault(p => p.nombre.Equals(producto.nombre, StringComparison.OrdinalIgnoreCase));

            if (producto_Existente != null)
            {
                 return "EL PRODUCTO YA EXISTE";
            }
            return null;
        }
        public List<Producto> Lista_Productos()
        {
            Producto_Repositorio producto_repositorio = new Producto_Repositorio();
            List<Producto> lista_Productos = producto_repositorio.Consultar_Producto();
            return lista_Productos;
        }
        public Producto Consultar_Producto(int id)
        {
            List<Producto> lista_Productos = Lista_Productos();
            Producto producto = lista_Productos.FirstOrDefault(p => p.id == id);
            return producto;
        }
        public string Eliminar_Producto (int id)
        {
            Producto_Repositorio producto_repositorio = new Producto_Repositorio();
            producto_repositorio.Eliminar_Producto(id);
            return "PRODCUTO ELIMINAR";
        }
        public string Actualizar_Producto (Producto producto)
        {
            Producto_Repositorio producto_repositorio = new Producto_Repositorio();

            string respuesta = Validar_Campos(producto);
            if (respuesta != null)
            {
                return respuesta;
            }
            respuesta = Validar_Existencia(producto);
            if (respuesta != null)
            {
                return respuesta;
            }
            producto_repositorio.Actualizar_Producto(producto);
            return "PRODUCTO ACTUALIZADO";
        }
        public void Restar_Stock(Producto producto, int cantidad)
        {
            Producto_Repositorio producto_Repositorio = new Producto_Repositorio();
            producto_Repositorio.Actualizar_Cantidad_Resta_Producto(producto,cantidad);
        }
        public void Sumar_Stock(Producto producto, int cantidad)
        {
            Producto_Repositorio producto_Repositorio = new Producto_Repositorio();
            producto_Repositorio.Actualizar_Cantidad_Suma_Producto(producto, cantidad);
        }
    }
}
