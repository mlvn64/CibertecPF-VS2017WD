using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Requests
{
    public class NuevoCliente
    {
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string RUC { get; set; }
        public string Sexo { get; set; }
        public string TipoCliente { get; set; }
        public string Estado { get; set; }
    }
}
