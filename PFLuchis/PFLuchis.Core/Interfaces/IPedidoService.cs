﻿using PFLuchis.Core.Entities;
using PFLuchis.Core.Requests;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Interfaces
{
    public interface IPedidoService
    {
        bool RegistrarNuevoPedido(NuevoPedido nuevoPedido);
        IEnumerable<Pedido> ListarTodosLosPedidos();
    }
}
