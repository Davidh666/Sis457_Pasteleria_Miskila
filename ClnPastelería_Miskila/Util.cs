using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPastelería_Miskila
{
   public enum Estado
    {
        Pendiente = 1,
        EnProceso = 2,
        Completado = 3,
        Cancelado = 4
    }
    public enum Disponible
    {
        Disponible = 1,
        NoDisponible = 0
    }
}
