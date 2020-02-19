using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class CartaService : ICartaService
    {
        //campo para utilizar el contexto
        private readonly IPFLuchisContext _pfLuchisContext;

        public CartaService(IPFLuchisContext pfLuchisContext)
        {
            _pfLuchisContext = pfLuchisContext;
        }

        public IEnumerable<CartaRegistrada> ListarCartasPorCategoria(int categoriaId)
        {
            return _pfLuchisContext.Cartas
                .Where(x => x.CategoriaId.Equals(categoriaId))
                .ToList()
                .Select(x => new CartaRegistrada()
                    {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    PrecioUnitario = x.Precio
                });
            //using (var db = new VentasDB())
            //{
            //    return db.Cartas
            //        .Where(x => x.CategoriaId.Equals(categoriaId))
            //        .ToList()
            //        .Select(x => x.ConvertirADTO());
            //}
        }

        public IEnumerable<CategoriaRegistrada> ListarTodasLasCategorias()
        {

            return _pfLuchisContext.Categorias.ToList()
                .Select(categoria => new CategoriaRegistrada()
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
                });
            ;
            //using (var db = new VentasDB())
            //{
            //    return db.Categorias.ToList().Select(x => x.ConvertirADTO());
            //}
        }
    }
}
