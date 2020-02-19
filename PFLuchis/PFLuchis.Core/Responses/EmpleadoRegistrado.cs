using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Responses
{
    public class EmpleadoRegistrado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string Estado { get; set; }
    }
}
