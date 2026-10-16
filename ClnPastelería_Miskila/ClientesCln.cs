using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    internal class ClientesCln
    {
        public static int crearCliente(Clientes cliente)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Clientes.Where(c => c.celular == cliente.celular).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El cliente con el código " + cliente.celular + " ya existe.");
                }
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return cliente.id_cliente;
            }
        }
        public static int actualizarCliente(Clientes cliente)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Clientes.Where(c => c.id_cliente == cliente.id_cliente).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El cliente con el código " + cliente.id_cliente + " no existe.");
                }
                existe.nombre = cliente.nombre;
                existe.celular = cliente.celular;
                existe.contrasena_hash = cliente.contrasena_hash;
                context.SaveChanges();
                return existe.id_cliente;
            }
        }
        public static int eliminarCliente(int id_cliente)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var existe = context.Clientes.Find(id_cliente);
                if (existe == null)
                {
                    throw new Exception("El cliente con el código " + id_cliente + " no existe.");
                }
                context.Clientes.Remove(existe);
                context.SaveChanges();
                return id_cliente;
            }
        }
        public static Clientes obtenerCliente(int id_cliente)
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                var cliente = context.Clientes.Find(id_cliente);
                if (cliente == null)
                {
                    throw new Exception("El cliente con el código " + id_cliente + " no existe.");
                }
                return cliente;
            }

        }
        public static List<Clientes> obtenerClientes()
        {
            using (var context = new Pastelería_MiskilaEntities())
            {
                return context.Clientes.ToList();
            }
        }
    }
}
