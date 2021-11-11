using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spmedical.Domains;
using spmedical.Interfaces;
using spmedical.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository Tipo { get; set; }

        public UsuarioController()
        {
            Tipo = new UsuarioRepository();
        }


        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novaUsuarioPossui)
        {
            try
            {
                Tipo.Cadastrar(novaUsuarioPossui);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id, Usuario UsuarioDeletar)
        {
            try
            {
                Tipo.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario  UsuarioAtualizada)
        {
            try
            {
                Tipo.Atualizar(id, UsuarioAtualizada);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
