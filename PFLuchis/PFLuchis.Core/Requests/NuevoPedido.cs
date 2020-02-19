using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Requests
{
    public class NuevoPedido
    {
        public int MesaId { get; set; }
        public int EmpleadoId { get; set; }
        public double Total { get; set; }
        public string EstadoPedido { get; set; }
        public IEnumerable<DetalleDelNuevoPedido> Detalles { get; set; }

    }
}
