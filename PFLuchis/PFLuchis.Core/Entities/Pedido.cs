using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Pedido : EntidadBase
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int MesaId { get; set; }
        public int EmpleadoId { get; set; }
        public double Total { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public HashSet<DetallePedido> DetallePedidos { get; set; }
        ////[ForeignKey("Mesa")]        
        public Mesa Mesa { get; set; }
        public Empleado Empleado { get; set; }
    }
}
