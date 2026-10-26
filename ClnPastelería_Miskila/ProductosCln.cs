using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    public class ProductoCln
    {
        public static int crear(Productos producto)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Productos.Where(x => x.nombre == producto.nombre && x.estado != -1).FirstOrDefault();
                if (existe != null) throw new Exception($"El producto '{producto.nombre}' ya existe");

                producto.estado = 1; // Activo por defecto
                context.Productos.Add(producto);
                context.SaveChanges();
                return producto.id_producto;
            }
        }

        public static int actualizar(Productos producto)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Productos.Find(producto.id_producto);
                if (existe == null) throw new Exception($"El producto con id {producto.id_producto} no existe");

                existe.nombre = producto.nombre;
                existe.descripcion = producto.descripcion;
                existe.precio = producto.precio;
                existe.disponible = producto.disponible;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Productos.Find(id);
                if (existe == null) throw new Exception($"El producto con id {id} no existe");

                existe.estado = -1; // Eliminación lógica
                return context.SaveChanges();
            }
        }

        public static Productos obtenerUno(int id)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var producto = context.Productos.Find(id);
                if (producto == null) throw new Exception($"El producto con id {id} no existe");
                return producto;
            }
        }

        public static List<Productos> listar(string parametro)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                // Desactivamos la carga perezosa y la creación de proxies dinámicos
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                return context.Productos
                    .Where(x => x.estado != -1 && (string.IsNullOrEmpty(parametro) || x.nombre.Contains(parametro)))
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }
    }
}