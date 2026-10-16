using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    internal class ProductosCln
    {
        public static int crearProducto(Productos producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Productos.Where(p => p.id_producto == producto.id_producto).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El producto con el código " + producto.id_producto + " ya existe.");
                }
                context.Productos.Add(producto);
                context.SaveChanges();
                return producto.id_producto;
            }
        }
        public static int actualizarProducto(Productos producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Productos.Where(p => p.id_producto == producto.id_producto).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El producto con el código " + producto.id_producto + " no existe.");
                }
                existe.nombre = producto.nombre;
                existe.descripcion = producto.descripcion;
                existe.precio = producto.precio;
                existe.imagen = producto.imagen;
                existe.disponible = producto.disponible;
                return context.SaveChanges();
            }
        }
        public static int eliminarProducto(int id_producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Productos.Find(id_producto);
                if (existe == null)
                {
                    throw new Exception("El producto con el código " + id_producto + " no existe.");
                }
                context.Productos.Remove(existe);
                return context.SaveChanges();
            }
        }
        public static Productos obtenerProducto(int id_producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var producto = context.Productos.Find(id_producto);
                if (producto == null)
                {
                    throw new Exception("El producto con el código " + id_producto + " no existe.");
                }
                return producto;
            }
        }
        public static List<Productos> obtenerProductosDisponibles()
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var productos = context.Productos.Where(p => p.disponible == true).ToList();
                return productos;
            }
        }
    }
}
