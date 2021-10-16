using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing;
using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using SP_MedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SP_MedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
       public class MedicosController : ControllerBase
       {
            private IMedicoRepository _medicoRepository { get; set; }

            public MedicosController()
            {
                _medicoRepository = new MedicoRepository();
            }

            public IActionResult ListarTodos()
            {
                try
                {
                    return Ok(_medicoRepository.ListarTodos());
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            public IActionResult BuscarPorId(int idMedico)
            {
                try
                {
                    Medico medicoBuscado = _medicoRepository.BuscarPorId(idMedico);

                    if (medicoBuscado != null)
                    {
                        return Ok(medicoBuscado);
                    }

                    return BadRequest("O medico requisitado não existe");

                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            public IActionResult Cadastrar(Medico novoMedico)
            {
                try
                {
                    _medicoRepository.Cadastrar(novoMedico);

                    return StatusCode(201);

                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            public IActionResult Atualizar(int idMedico, Medico medicoAtualizado)
            {
                try
                {
                    _medicoRepository.Atualizar(idMedico, medicoAtualizado);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            public IActionResult Deletar(int idMedico)
            {
                try
                {
                    _medicoRepository.Deletar(idMedico);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            public override bool Equals(object obj)
            {
                return obj is MedicosController controller &&
                       EqualityComparer<HttpContext>.Default.Equals(HttpContext, controller.HttpContext) &&
                       EqualityComparer<HttpRequest>.Default.Equals(Request, controller.Request) &&
                       EqualityComparer<HttpResponse>.Default.Equals(Response, controller.Response) &&
                       EqualityComparer<RouteData>.Default.Equals(RouteData, controller.RouteData) &&
                       EqualityComparer<ModelStateDictionary>.Default.Equals(ModelState, controller.ModelState) &&
                       EqualityComparer<ControllerContext>.Default.Equals(ControllerContext, controller.ControllerContext) &&
                       EqualityComparer<IModelMetadataProvider>.Default.Equals(MetadataProvider, controller.MetadataProvider) &&
                       EqualityComparer<IModelBinderFactory>.Default.Equals(ModelBinderFactory, controller.ModelBinderFactory) &&
                       EqualityComparer<IUrlHelper>.Default.Equals(Url, controller.Url) &&
                       EqualityComparer<IObjectModelValidator>.Default.Equals(ObjectValidator, controller.ObjectValidator) &&
                       EqualityComparer<ProblemDetailsFactory>.Default.Equals(ProblemDetailsFactory, controller.ProblemDetailsFactory) &&
                       EqualityComparer<ClaimsPrincipal>.Default.Equals(User, controller.User) &&
                       EqualityComparer<IMedicoRepository>.Default.Equals(_medicoRepository, controller._medicoRepository);
            }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    }
}
