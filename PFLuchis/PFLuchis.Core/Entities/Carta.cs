using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Carta: EntidadBase
    {
        //public int CartaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Estado Estado { get; set; }
        public Categoria Categoria { get; set; }

    }

    
}
