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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult BuscarPorId(int idPaciente)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(idPaciente);

                if (pacienteBuscado != null)
                {
                    return Ok(pacienteBuscado);
                }

                return BadRequest("O paciente requisitado não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.Atualizar(idPaciente, pacienteAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Deletar(int idPaciente)
        {
            try
            {
                _pacienteRepository.Deletar(idPaciente);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}