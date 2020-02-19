using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Venta : EntidadBase
    {
        public int NroVenta { get; set; }
        public int ClienteId { get; set; }
        public int PedidoId { get; set; }
        public TipoDeVenta TipoDeVenta { get; set; }
        public DateTime Fecha { get; set; }
        //public double SubTotal { get; set; }
        //public double Igv { get; set; }
        public double Total { get; set; }
        public Cliente Cliente { get; set; }
        public Pedido Pedido { get; set; }
    }
}
