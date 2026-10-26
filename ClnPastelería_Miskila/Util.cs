using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPastelería_Miskila
{
    public enum Estado { Activo = 1, Inactivo = 0, Eliminado = -1 };
    public enum Disponible
    {
        Disponible = 1,
        NoDisponible = 0
    }
    public enum RolUsuario
    {
        Administrador = 1,
        Cliente = 2
    }
}
