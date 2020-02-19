using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFLuchis.Core.Interfaces;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IPFLuchisContext _context;
        private readonly IMesaService _mesaService;

        public MesasController(IPFLuchisContext context, IMesaService mesaService)
        {
            _context = context;
            _mesaService = mesaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ListarTodos")]
        public ActionResult ListarTodos()
        {
            return Ok(_mesaService.ListarTodasLasMesas());
        }
    }
}