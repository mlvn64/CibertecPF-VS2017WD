using Microsoft.EntityFrameworkCore;
using PFLuchis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Core.Interfaces
{
    public interface IPFLuchisContext
    {
        DbSet<Carta> Cartas { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<DetallePedido> DetallePedidos { get; set; }
        DbSet<Empleado> Empleados { get; set; }
        DbSet<Mesa> Mesas { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<Venta> Ventas { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }

        /// <summary>
        /// Internamente este método invocará el método SaveChange del Contexto
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Método para migrar la BD
        /// </summary>
        /// <returns></returns>     
        bool Migrate();

    }
}
