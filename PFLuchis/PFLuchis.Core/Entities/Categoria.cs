using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Categoria : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public HashSet<Carta> Cartas { get; set; }
    }
}
