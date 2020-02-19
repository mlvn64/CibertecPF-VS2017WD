using PFLuchis.Core.Entities;
using PFLuchis.Core.Entities.Compartido.Enums;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class PedidoService : IPedidoService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public PedidoService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }
        public IEnumerable<Pedido> ListarTodosLosPedidos()
        {
            throw new NotImplementedException();
        }

        public bool RegistrarNuevoPedido(NuevoPedido nuevoPedido)
        {            
            HashSet<DetallePedido> detallePedidos = new HashSet<DetallePedido>(
                nuevoPedido.Detalles.Select(x => new DetallePedido()
                {
                    CartaId = x.CartaId,
                    Cantidad = x.Cantidad
                }));

            var insertarPedido = new Pedido()
            {
                Fecha = DateTime.Now,
                MesaId = nuevoPedido.MesaId,
                EmpleadoId = nuevoPedido.EmpleadoId,
                Total = nuevoPedido.Total,
                EstadoPedido = nuevoPedido.EstadoPedido.Equals("EnProceso") ? EstadoPedido.EnProceso : EstadoPedido.Atendido,
                DetallePedidos = detallePedidos
            };

            _pfLuchisContext.Pedidos.Add(insertarPedido);

            return _pfLuchisContext.Commit() > 0;

            //    using (var db = new VentasDB())
            //{
            //    Pedido pedido = nuevoPedido.ConvertirAEntidad();
            //    db.Pedidos.Add(pedido);
            //    db.SaveChanges();

            //    return pedido.Id;
            //}
        }
    }
}
