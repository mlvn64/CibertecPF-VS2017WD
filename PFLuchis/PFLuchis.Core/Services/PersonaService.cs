using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class PersonaService : IPersonaService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public PersonaService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        public IEnumerable<PersonaGenerica> ListarClientes()
        {
            return _pfLuchisContext.Clientes
                .ToList()
                .Select(x => new PersonaGenerica()
                {
                    Id = x.Id,
                    NombreCompleto = x.NombreCompleto

                });
        }

        public IEnumerable<PersonaGenerica> ListarEmpleados()
        {
            return _pfLuchisContext.Empleados
                .ToList()
                .Select(x => new PersonaGenerica()
                {
                    Id = x.Id,
                    NombreCompleto = x.NombreCompleto

                });
        }
    }
}
