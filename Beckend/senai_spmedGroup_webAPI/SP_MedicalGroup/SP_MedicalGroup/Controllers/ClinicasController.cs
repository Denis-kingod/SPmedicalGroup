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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_clinicaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult BuscarPorId(int idClinica)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(idClinica);

                if (clinicaBuscada != null)
                {
                    return Ok(clinicaBuscada);
                }

                return BadRequest("A clinica requisitada não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Cadastrar(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        public IActionResult Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            try
            {
                _clinicaRepository.Atualizar(idClinica, clinicaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        public IActionResult Deletar(int idClinica)
        {
            try
            {
                _clinicaRepository.Deletar(idClinica);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}