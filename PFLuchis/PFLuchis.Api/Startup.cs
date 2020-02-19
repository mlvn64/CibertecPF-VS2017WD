using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Services;
using PFLuchis.Infra.Data;

namespace PFLuchis.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configurar el contexto de EF            
            services.AddDbContext<IPFLuchisContext, PFLuchisContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PFLuchisConnection")));

            /////services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartaService,CartaService>();
            services.AddTransient<IMesaService, MesaService>();
            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IAccountService, AccountService>();


            // configurar la autenticación con JWT
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerConfig =>
            {
                // solo para pruebas (en prod debería ser true)
                bearerConfig.RequireHttpsMetadata = false;
                bearerConfig.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("cibertec12345678")),
                    ValidIssuer = "Cibertec",
                    ValidAudience = "app-react",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(10) // en producción debe ser un valor mayor (por defecto es 5 minutos)
                };
            });

            // configurar el policy para habilitar la autenticación a nivel global
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder(new[] { JwtBearerDefaults.AuthenticationScheme }).RequireAuthenticatedUser().Build();
            });


            //////agregar el servicio de CORS  -- esto te indica que dominio puede accedera tu API
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // configurar CORS
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(host => true));

            // habilitar el servicio de autenticación en el app
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
