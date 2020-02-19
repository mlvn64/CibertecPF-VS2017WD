using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFLuchis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPFLuchisContext _context;
        private readonly IPersonaService _personaService;

        public PersonasController(IPFLuchisContext context, IPersonaService personaService)
        {
            _context = context;
            _personaService = personaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Clientes")]
        //[Route("api/Personas/Clientes")]
        public ActionResult Clientes()
        {
            return Ok(_personaService.ListarClientes());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Empleados")]
        //[Route("api/Personas/Empleados")]
        public ActionResult Empleados()
        {
            return Ok(_personaService.ListarEmpleados());
        }
    }
}
