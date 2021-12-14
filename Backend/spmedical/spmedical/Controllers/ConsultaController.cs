using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spmedical.Domains;
using spmedical.Interfaces;
using spmedical.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository Con { get; set; }

        public ConsultaController()
        {
            Con = new ConsultaRepository();
        }

 

        [Authorize(Roles = "1")]
        [HttpGet("ListarTodas")]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(Con.ListarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Roles = "2,3")]
        [HttpGet("Minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(Con.ListarMinhas(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(Con.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPost]
        public IActionResult NovoCon(Consultum NovoCon)
        {
            try
            {
                Con.Cadastrar(NovoCon);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id, Consultum idConsulta)
        {
            try
            {
                Con.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public IActionResult AtualizarDados(int id, Consultum NovaCon)
        {
            try
            {
                Con.Atualizar(id, NovaCon);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
