using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadPastelería_Miskila;

namespace ClnPastelería_Miskila
{
    public class UsuarioCln
    {
        public static int crearUsuario(Usuarios usuario)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Usuarios.Where(u => u.email == usuario.email).FirstOrDefault();
                if (existe != null)
                {
                    throw new Exception("El usuario con el email " + usuario.email + " ya existe.");
                }
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return usuario.id_usuario;
            }
        }

        public static int actualizarUsuario(Usuarios usuario)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Usuarios.Where(u => u.id_usuario == usuario.id_usuario).FirstOrDefault();
                if (existe == null)
                {
                    throw new Exception("El usuario con el ID " + usuario.id_usuario + " no existe.");
                }
                existe.contrasena_hash = usuario.contrasena_hash;
                existe.nombre = usuario.nombre;
                existe.rol = usuario.rol;
                existe.estado = usuario.estado;
                return context.SaveChanges();
            }
        }

        public static int eliminarUsuario(int id)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var existe = context.Usuarios.Find(id);
                if (existe == null)
                {
                    throw new Exception("El usuario con el ID " + id + " no existe.");
                }
                context.Usuarios.Remove(existe);
                return context.SaveChanges();
            }
        }

        public static Usuarios obtenerUsuario(int id)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var usuario = context.Usuarios.Find(id);
                if (usuario == null)
                {
                    throw new Exception("El usuario con el ID " + id + " no existe.");
                }
                return usuario;
            }
        }

        public static List<Usuarios> obtenerTodosUsuarios()
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                return context.Usuarios.ToList();
            }
        }
        public static List<Usuarios> listar(string parametro)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {

                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                return context.Usuarios
                    .Where(x => x.estado != -1 && (string.IsNullOrEmpty(parametro) || x.nombre.Contains(parametro) || x.email.Contains(parametro))).OrderBy(x => x.nombre).ToList();
            }
        }
        public static Usuarios autenticar(string emailOCelular, string contrasena)
        {
            using (var context = new LabPastelería_MiskilaEntities())
            {
                var usuario = context.Usuarios
                    .FirstOrDefault(u => (u.email == emailOCelular || u.celular == emailOCelular)
                                      && u.contrasena_hash == contrasena
                                      && u.estado == 1);

                if (usuario == null)
                {
                    throw new Exception("El usuario o la contraseña son incorrectos, o la cuenta está inactiva.");
                }

                return usuario; 
            }
        }
    }

}