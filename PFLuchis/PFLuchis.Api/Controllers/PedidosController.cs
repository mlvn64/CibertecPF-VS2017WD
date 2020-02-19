using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPFLuchisContext _context;
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPFLuchisContext context, IPedidoService pedidoService)
        {
            _context = context;
            _pedidoService = pedidoService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Insertar(NuevoPedido nuevoPedido)
        {
            var registroCorrecto = _pedidoService.RegistrarNuevoPedido(nuevoPedido);
            if (!registroCorrecto)
            {
                return BadRequest("Ocurrió un error con la solicitud enviada");
            }
            return Ok("se registró el pedido satisfactoriamente");
            //return Ok(_pedidoService.RegistrarNuevoPedido(nuevoPedido));
        }
    }
}
