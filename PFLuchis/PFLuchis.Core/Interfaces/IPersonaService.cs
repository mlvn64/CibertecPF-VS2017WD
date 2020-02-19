using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<PersonaGenerica> ListarClientes();
        IEnumerable<PersonaGenerica> ListarEmpleados();
    }
}
