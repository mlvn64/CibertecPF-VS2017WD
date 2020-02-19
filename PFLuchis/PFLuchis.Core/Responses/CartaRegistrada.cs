using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Responses
{
    public class CartaRegistrada
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
