﻿using PFLuchis.Core.Entities;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Interfaces
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoRegistrado> ListarTodosLosEmpleados();
    }
}
