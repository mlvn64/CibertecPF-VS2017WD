using Microsoft.AspNetCore.Mvc;
using PFLuchis.Core.Interfaces;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DatabaseController: ControllerBase
    {
        private readonly IPFLuchisContext _pfLuchisContext;
        public DatabaseController(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        [HttpGet("migrar")]
        public string Migrar()
        {
            //migrar la BD utilizando el contexto
            _pfLuchisContext.Migrate();
            return "Migración exitosa";
        }
    }
}
