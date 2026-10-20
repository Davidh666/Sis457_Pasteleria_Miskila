using CadPastelería_Miskila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPastelería_Miskila
{
    public class UsuarioCln
    {
        public static Usuarios validar(string usuario, string clave)
        {
            using (var context = new LabPastelería_MiskilaEntities1())
            {
                // Usamos 'identificador' y 'contrasena_hash' tal como vienen en el modelo .edmx
                return context.Usuarios
                    .Where(x => x.identificador == usuario && x.contrasena_hash == clave && x.estado != -1)
                    .FirstOrDefault();
            }
        }
    }
}