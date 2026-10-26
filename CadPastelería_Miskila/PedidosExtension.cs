using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadPastelería_Miskila
{
    public partial class Pedidos
    {
        public string NombreCliente
        {
            get { return Usuarios != null ? Usuarios.nombre : string.Empty; }
        }
    }
}
