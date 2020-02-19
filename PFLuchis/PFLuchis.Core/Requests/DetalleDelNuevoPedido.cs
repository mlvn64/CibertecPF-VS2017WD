using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Requests
{
    public class DetalleDelNuevoPedido
    {
        public int CartaId { get; set; }
        public int Cantidad { get; set; }
    }
}
