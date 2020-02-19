using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Mesa : EntidadBase
    {
        public string Nombre { get; set; }
        public EstadoMesa EstadoMesa { get; set; }
        public Estado Estado { get; set; }
        public HashSet<Pedido> Pedido { get; set; }
    }
}
