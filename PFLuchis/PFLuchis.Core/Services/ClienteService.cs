using PFLuchis.Core.Entities;
using PFLuchis.Core.Entities.Compartido.Enums;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Requests;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class ClienteService : IClienteService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public ClienteService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        public bool RegistrarNuevoCliente(NuevoCliente nuevoCliente)
        {
            //throw new NotImplementedException();
            //Cliente cliente = new Cliente();
            var insertarCliente = new Cliente()
            {
                NombreCompleto = nuevoCliente.NombreCompleto,
                DNI = nuevoCliente.DNI,
                Direccion = nuevoCliente.Correo,
                Correo = nuevoCliente.Correo,
                Celular = nuevoCliente.Celular,
                RUC = nuevoCliente.RUC,
                Sexo = nuevoCliente.Sexo.Equals("Masculino") ? Sexo.Masculino : Sexo.Femenino,
                TipoCliente = nuevoCliente.TipoCliente.Equals("PN") ? TipoCliente.PN : TipoCliente.PJ,
                Estado = nuevoCliente.Estado.Equals("Activo") ? Estado.Activo : Estado.Desactivado

            };

            _pfLuchisContext.Clientes.Add(insertarCliente);

            return _pfLuchisContext.Commit() > 0;
                
        }
    }
}
