using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using PFLuchis.Core.Requests;
using PFLuchis.Core.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PFLuchis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        //private readonly ICibertecContext _cibertecContext;
        private readonly IPFLuchisContext _context;

        public AccountController(IAccountService accountService, IPFLuchisContext cibertecContext)
        {
            _accountService = accountService;
            _context = cibertecContext;
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public ActionResult GetToken(GetTokenRequest request)
        {
            // 1. Validar el usuario
            var usuario = _accountService.ValidateUser(request.Username, request.Password);

            if (usuario == null)
            {
                // devolver un 401 (no autorizado)
                return StatusCode(401);
            }

            // 2. Crear la identidad del usuario (que viajará en el JWT)
            var identidad = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Name),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("DNI", usuario.Dni)
            };

            // 3. Crear los elementos para la encriptación
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("cibertec12345678"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. Generar el token
            // 4.1. Obtener la fecha de expiración del token
            var tokenExpirationDate = DateTime.Now.AddSeconds(10);

            var token = new JwtSecurityToken(
                issuer: "Cibertec",
                audience: "app-react",
                claims: identidad,
                expires: tokenExpirationDate,
                signingCredentials: credenciales
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            // 5. Crear el refresh token
            var refreshToken = new RefreshToken
            {
                ExpiresAt = tokenExpirationDate,
                UserId = usuario.Id,
                Token = Guid.NewGuid().ToString()
            };

            // 5.1. Guardar en BD
            _context.RefreshTokens.Add(refreshToken);
            var resultado = _context.Commit();

            // 6. Retornar el token en un objeto JSON basado en la clase GetTokenResponse
            return Ok(new GetTokenResponse { AccessToken = jwtToken, RefreshToken = refreshToken.Token, ExpiresIn = 10 });
        }

        [HttpPost("token/refresh")]
        [AllowAnonymous]
        public ActionResult RefreshToken(RefreshTokenRequest request)
        {
            // 1. Obtener el registro de la BD
            var refreshToken = _context.RefreshTokens.FirstOrDefault(r => r.Token == request.RefreshToken);

            if (refreshToken == null)
            {
                // develover 401
                return StatusCode(401);
            }

            // 1.1 Validar la fecha de expiración
            // TODO


            // 2. Obtener el usuario
            var usuario = _context.Users.Find(refreshToken.UserId);

            if (usuario == null)
            {
                // devolver un 401 (no autorizado)
                return StatusCode(401);
            }

            // 2. Crear la identidad del usuario (que viajará en el JWT)
            var identidad = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Name),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("DNI", usuario.Dni)
            };

            // 3. Crear los elementos para la encriptación
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("cibertec12345678"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. Generar el token
            // 4.1. Obtener la fecha de expiración del token
            var tokenExpirationDate = DateTime.Now.AddSeconds(10);

            var token = new JwtSecurityToken(
                issuer: "Cibertec",
                audience: "app-react",
                claims: identidad,
                expires: tokenExpirationDate,
                signingCredentials: credenciales
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            // 5. Actualizar el refresh token
            refreshToken.Token = Guid.NewGuid().ToString();
            refreshToken.ExpiresAt = tokenExpirationDate;

            // 5.1. Guardar cambios en BD
            var resultado = _context.Commit();

            // 6. Retornar el token en un objeto JSON basado en la clase GetTokenResponse
            return Ok(new GetTokenResponse { AccessToken = jwtToken, RefreshToken = refreshToken.Token, ExpiresIn = 10 });
        }
    }
}
