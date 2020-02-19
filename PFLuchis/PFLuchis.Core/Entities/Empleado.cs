using PFLuchis.Core.Entities.Compartido;
using PFLuchis.Core.Entities.Compartido.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class Empleado : PersonaContacto
    {
        public Sexo Sexo { get; set; }
        public Estado Estado { get; set; }
        public HashSet<Pedido> Pedidos { get; set; }
    }
}
