using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartasController: ControllerBase
    {
        private readonly IPFLuchisContext _context;
        private readonly ICartaService _cartaService;
                
        public CartasController(IPFLuchisContext context, ICartaService cartaService)
        {
            _context = context;
            _cartaService = cartaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Categorias")]
        public ActionResult Categorias()
        {
            return Ok(_cartaService.ListarTodasLasCategorias());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("CartasPorCategoria/{id}")]
        public ActionResult CartasPorCategoria( int id)
        {
            return Ok(_cartaService.ListarCartasPorCategoria(id));
        }

    }
}
