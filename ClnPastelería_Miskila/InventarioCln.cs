using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    internal class InventarioCln
    {
        public static int crearInventario(Inventario inventario)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Inventario.Where(i => i.id_producto == inventario.id_producto).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El inventario con el código " + inventario.id_producto + " ya existe.");
                }
                context.Inventario.Add(inventario);
                context.SaveChanges();
                return inventario.id_producto;
            }
        }
        public static int actualizarInventario(Inventario inventario)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Inventario.Where(i => i.id_producto == inventario.id_producto).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El inventario con el código " + inventario.id_producto + " no existe.");
                }
                existe.cantidad_disponible = inventario.cantidad_disponible;
                existe.fecha_actualizacion = inventario.fecha_actualizacion;
                return context.SaveChanges();
            }
        }
        public static int eliminarInventario(int id_producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Inventario.Find(id_producto);
                if (existe == null)
                {
                    throw new Exception("El inventario con el código " + id_producto + " no existe.");
                }
                context.Inventario.Remove(existe);
                return context.SaveChanges();
            }
        }
        public static Inventario obtenerInventario(int id_producto)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var inventario = context.Inventario.Find(id_producto);
                if (inventario == null)
                {
                    throw new Exception("El inventario con el código " + id_producto + " no existe.");
                }
                return inventario;
            }
        }
        public static List<Inventario> obtenerTodosInventarios()
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                return context.Inventario.ToList();
            }
        }
    }
}
