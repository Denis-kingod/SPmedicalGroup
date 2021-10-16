using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using SP_MedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult BuscarPorId(int idUsuario)
        {
            try
            {
                Usuario usuarioBuscada = _usuarioRepository.BuscarPorId(idUsuario);

                if (usuarioBuscada != null)
                {
                    return Ok(usuarioBuscada);
                }

                return BadRequest("O usuario requisitada não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Deletar(int idUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(idUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}