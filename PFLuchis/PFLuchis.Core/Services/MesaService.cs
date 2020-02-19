using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class MesaService : IMesaService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public MesaService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        public IEnumerable<MesaRegistrada> ListarTodasLasMesas()
        {
            return _pfLuchisContext.Mesas.ToList()
                .Select(x=> new MesaRegistrada()
                {   Id = x.Id,
                    Nombre = x.Nombre,
                    EstadoMesa = x.EstadoMesa.ToString()
                });
            //using (var db = new VentasDB())
            //{
            //    return db.Mesas.ToList().Select(x => x.ConvertirADTO());
            //}
        }
    }
}
