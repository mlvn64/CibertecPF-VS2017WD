using Microsoft.EntityFrameworkCore;
using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFLuchis.Infra.Data
{
    public class PFLuchisContext: DbContext, IPFLuchisContext
    {
        public PFLuchisContext(DbContextOptions<PFLuchisContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public int Commit()
        {
            return SaveChanges();
        }

        public bool Migrate()
        {
            try
            {
                Database.Migrate();
                return true;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        //agregar los DB SET que serán las tablas que se crearán en la BD
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Rol> Roles { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
