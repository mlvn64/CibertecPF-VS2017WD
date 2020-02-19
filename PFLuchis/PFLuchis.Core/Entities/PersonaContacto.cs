using PFLuchis.Core.Entities.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Entities
{
    public class PersonaContacto: EntidadBase
    {
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
    }
}
