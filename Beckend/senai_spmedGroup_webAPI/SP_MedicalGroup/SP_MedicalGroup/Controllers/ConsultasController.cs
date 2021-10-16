using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    erro
                });
            }
        }

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Consultum consultaBuscada = _consultaRepository.BuscarPorId(id);

                if (consultaBuscada != null)
                {
                    return Ok(consultaBuscada);
                }

                return BadRequest("A consulta requisitada não existe");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult Cancela(int idConsulta, Consultum status)
        {
            try
            {
                _consultaRepository.Cancela(idConsulta, status.IdSituacaoPaciente.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult AdicionaDescricao(int idConsulta, Consultum novaConsulta)
        {
            try
            {
                _consultaRepository.AdicionarDecrição(idConsulta, novaConsulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(idConsulta, consultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Deletar(int idConsulta)
        {
            try
            {
                _consultaRepository.Deletar(idConsulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }

    internal class ConsultaRepository : IConsultaRepository
    {
        public void AdicionarDecrição(int idConsulta, Consultum ConsultaComDescricao)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            throw new NotImplementedException();
        }

        public void Cancela(int idConsulta, string status)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idConsulta)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarMinhas(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarTodas()
        {
            throw new NotImplementedException();
        }
    }
}