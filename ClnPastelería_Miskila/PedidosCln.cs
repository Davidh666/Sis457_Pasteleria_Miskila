using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    public class PedidosCln
    {
        public static int crearPedido(Pedidos pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Pedidos.Where(p => p.id_pedido == pedido.id_pedido).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El pedido con el código " + pedido.id_pedido + " ya existe.");
                }
                context.Pedidos.Add(pedido);
                context.SaveChanges();
                return pedido.id_pedido;
            }
        }
        public static int actualizarPedido(Pedidos pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Pedidos.Where(p => p.id_pedido == pedido.id_pedido).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El pedido con el código " + pedido.id_pedido + " no existe.");
                }
                existe.fecha_pedido = pedido.fecha_pedido;
                existe.fecha_entrega = pedido.fecha_entrega;
                existe.id_usuario = pedido.id_usuario;
                existe.total = pedido.total;
                existe.tipo_pedido = pedido.tipo_pedido;
                existe.estado = pedido.estado;
                existe.observaciones = pedido.observaciones;
                return context.SaveChanges();
            }
        }
        public static int eliminarPedido(int id_pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Pedidos.Find(id_pedido);
                if (existe == null)
                {
                    throw new Exception("El pedido con el código " + id_pedido + " no existe.");
                }
                context.Pedidos.Remove(existe);
                return context.SaveChanges();
            }
        }
        public static Pedidos obtenerPedido(int id_pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var pedido = context.Pedidos.Find(id_pedido);
                if (pedido == null)
                {
                    throw new Exception("El pedido con el código " + id_pedido + " no existe.");
                }
                return pedido;
            }
        }
        public static List<Pedidos> obtenerPedidos()
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                string estadoPendiente = Estado.Activo.ToString();
                return context.Pedidos.Where(p => p.estado == estadoPendiente).OrderBy(p => p.id_pedido).ToList();
            }
        }
        public static List<Pedidos> listar(string parametro)
        {
            var context = new LabPastelería_MiskilaEntities();
            return context.Pedidos
                          .Include("Usuarios")
                          .Where(p => p.estado != "-1" && (string.IsNullOrEmpty(parametro) || p.Usuarios.nombre.Contains(parametro)))
                          .ToList();
        }
    }
}
