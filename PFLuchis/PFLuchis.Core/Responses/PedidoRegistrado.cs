using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Responses
{
    public class PedidoRegistrado
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreMesa { get; set; }
        public string NombreEmpleado { get; set; }
        public double MontoTotal { get; set; }
    }
}
