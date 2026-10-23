using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    internal class DetallePedidoCln
    {
        public static int crearDetallePedido(DetallePedido detallePedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.DetallePedido.Where(d => d.id_detalle == detallePedido.id_detalle).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El detalle del pedido con el código " + detallePedido.id_detalle + " ya existe.");
                }
                context.DetallePedido.Add(detallePedido);
                context.SaveChanges();
                return detallePedido.id_detalle;
            }
        }
        public static int actualizarDetallePedido(DetallePedido detallePedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.DetallePedido.Where(d => d.id_detalle == detallePedido.id_detalle).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El detalle del pedido con el código " + detallePedido.id_detalle + " no existe.");
                }
                existe.id_pedido = detallePedido.id_pedido;
                existe.id_producto = detallePedido.id_producto;
                existe.cantidad = detallePedido.cantidad;
                existe.precio_unitario = detallePedido.precio_unitario;
                existe.subtotal = detallePedido.subtotal;
                return context.SaveChanges();
            }
        }
        public static int eliminarDetallePedido(int id_detalle)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.DetallePedido.Find(id_detalle);
                if (existe == null)
                {
                    throw new Exception("El detalle del pedido con el código " + id_detalle + " no existe.");
                }
                context.DetallePedido.Remove(existe);
                return context.SaveChanges();
            }
        }
        public static DetallePedido obtenerDetallePedido(int id_detalle)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var detallePedido = context.DetallePedido.Find(id_detalle);
                if (detallePedido == null)
                {
                    throw new Exception("El detalle del pedido con el código " + id_detalle + " no existe.");
                }
                return detallePedido;
            }
        }
        public static List<DetallePedido> obtenerDetallesPedidoPorIdPedido(int id_pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var detallesPedido = context.DetallePedido.Where(d => d.id_pedido == id_pedido).ToList();
                if (detallesPedido == null || detallesPedido.Count == 0)
                {
                    throw new Exception("No existen detalles del pedido con el código " + id_pedido + ".");
                }
                return detallesPedido;
            }
        }
    }
}
