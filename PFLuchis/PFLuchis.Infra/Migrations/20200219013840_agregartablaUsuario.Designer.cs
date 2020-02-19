﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PFLuchis.Infra.Data;

namespace PFLuchis.Infra.Migrations
{
    [DbContext(typeof(PFLuchisContext))]
    [Migration("20200219013840_agregartablaUsuario")]
    partial class agregartablaUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PFLuchis.Core.Entities.Carta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Descripcion");

                    b.Property<int>("Estado");

                    b.Property<string>("Nombre");

                    b.Property<double>("Precio");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Cartas");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<int>("Estado");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular");

                    b.Property<string>("Correo");

                    b.Property<string>("DNI");

                    b.Property<string>("Direccion");

                    b.Property<int>("Estado");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("RUC");

                    b.Property<int>("Sexo");

                    b.Property<int>("TipoCliente");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.DetallePedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CartaId");

                    b.Property<int>("PedidoId");

                    b.HasKey("Id");

                    b.HasIndex("CartaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular");

                    b.Property<string>("Correo");

                    b.Property<string>("DNI");

                    b.Property<string>("Direccion");

                    b.Property<int>("Estado");

                    b.Property<string>("NombreCompleto");

                    b.Property<int>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado");

                    b.Property<int>("EstadoMesa");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<int>("EstadoPedido");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("MesaId");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("MesaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("Token");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dni");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Roles");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("NroVenta");

                    b.Property<int>("PedidoId");

                    b.Property<int>("TipoDeVenta");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Carta", b =>
                {
                    b.HasOne("PFLuchis.Core.Entities.Categoria", "Categoria")
                        .WithMany("Cartas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.DetallePedido", b =>
                {
                    b.HasOne("PFLuchis.Core.Entities.Carta", "Carta")
                        .WithMany()
                        .HasForeignKey("CartaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PFLuchis.Core.Entities.Pedido", "Pedido")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Pedido", b =>
                {
                    b.HasOne("PFLuchis.Core.Entities.Empleado", "Empleado")
                        .WithMany("Pedidos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PFLuchis.Core.Entities.Mesa", "Mesa")
                        .WithMany("Pedido")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.RefreshToken", b =>
                {
                    b.HasOne("PFLuchis.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PFLuchis.Core.Entities.Venta", b =>
                {
                    b.HasOne("PFLuchis.Core.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PFLuchis.Core.Entities.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
