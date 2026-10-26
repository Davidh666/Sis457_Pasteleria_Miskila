using CadPastelería_Miskila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPastelería_Miskila
{
    public class PedidosCln
    {
        public static int crearPedido(Pedidos pedido, string nombreCliente)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                // Buscar si el cliente existe por su nombre, si no existe se puede manejar o crear aunque pienso cambiar por email
                var usuario = context.Usuarios.FirstOrDefault(u => u.nombre.ToLower() == nombreCliente.ToLower());
                if (usuario != null)
                {
                    pedido.id_usuario = usuario.id_usuario;
                }
                else
                {
                    throw new Exception("El cliente ingresado no existe en la base de datos de usuarios.");
                }

                pedido.fecha_pedido = DateTime.Now;
                pedido.estado = "Activo"; 
                pedido.estado_reg = 1;

                context.Pedidos.Add(pedido);
                context.SaveChanges();
                return pedido.id_pedido;
            }
        }

        public static int actualizarPedido(Pedidos pedido, string nombreCliente)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Pedidos.FirstOrDefault(p => p.id_pedido == pedido.id_pedido);
                if (existe == null)
                {
                    throw new Exception("El pedido con el código " + pedido.id_pedido + " no existe.");
                }

                var usuario = context.Usuarios.FirstOrDefault(u => u.nombre.ToLower() == nombreCliente.ToLower());
                if (usuario != null)
                {
                    existe.id_usuario = usuario.id_usuario;
                }
                else
                {
                    throw new Exception("El cliente ingresado no existe en la base de datos de usuarios.");
                }

                existe.fecha_entrega = pedido.fecha_entrega;
                existe.total = pedido.total;
                existe.tipo_pedido = pedido.tipo_pedido;
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
                
                existe.estado_reg = -1;
                return context.SaveChanges();
            }
        }

        public static Pedidos obtenerPedido(int id_pedido)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var pedido = context.Pedidos.Include("Usuarios").FirstOrDefault(p => p.id_pedido == id_pedido);
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
                return context.Pedidos.Include("Usuarios").Where(p => p.estado_reg != -1).OrderBy(p => p.id_pedido).ToList();
            }
        }

        public static List<Pedidos> listar(string parametro)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                return context.Pedidos
                              .Include("Usuarios")
                              .Where(p => p.estado_reg != -1 &&
                                          (string.IsNullOrEmpty(parametro) ||
                                           p.estado.Contains(parametro) ||
                                           p.tipo_pedido.Contains(parametro)))
                              .ToList();
            }
        }
    }
}