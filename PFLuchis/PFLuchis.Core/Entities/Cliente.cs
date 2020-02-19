using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Cliente : PersonaContacto
    {
        public string RUC { get; set; }
        public Sexo Sexo { get; set; }
        public Estado Estado { get; set; }
        public TipoCliente TipoCliente { get; set; }
        //public HashSet<Venta> Ventas { get; set; }
    }
}
