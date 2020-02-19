using PFLuchis.Core.Entities.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class DetallePedido : EntidadBase
    {
        public int PedidoId { get; set; }
        public int CartaId { get; set; }
        public int Cantidad { get; set; }
        public Pedido Pedido { get; set; }
        public Carta Carta { get; set; }
    }
}
