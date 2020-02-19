using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public EmpleadoService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        public IEnumerable<EmpleadoRegistrado> ListarTodosLosEmpleados()
        {
            return _pfLuchisContext.Empleados.ToList()
                .Select(empleado => new EmpleadoRegistrado()
                {
                    Id = empleado.Id,
                    NombreCompleto = empleado.NombreCompleto,
                    DNI = empleado.DNI,
                    Estado = empleado.Estado.ToString()

                });
            //using (var db = new VentasDB())
            //{
            //    return db.Empleados.ToList().Select(x => x.ConvertirADTO());
            //}
        }
    }
}
