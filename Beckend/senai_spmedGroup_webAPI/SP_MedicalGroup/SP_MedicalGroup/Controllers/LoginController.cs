using Acr.UserDialogs;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using SP_MedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario UsuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado == null)
                {
                    return BadRequest("Usuario ou senha inválidos");
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(

                    issuer: "spmed.webAPI",
                    audience: "spmed.webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}