
using Microsoft.EntityFrameworkCore;
using spmedical.Contexts;
using spmedical.Domains;
using spmedical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            Consultum ConBuscada = ctx.Consulta.Find(idConsulta);
            if (consultaAtualizada.DescricaoConsulta != null && consultaAtualizada.IdPaciente != null && consultaAtualizada.IdMedico != null && consultaAtualizada.IdSituacaoPaciente != null && consultaAtualizada.DataConsulta != null)
            {
                ConBuscada.DescricaoConsulta = consultaAtualizada.DescricaoConsulta;
                ConBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                ConBuscada.IdMedico = consultaAtualizada.IdMedico;
                ConBuscada.IdSituacaoPaciente = consultaAtualizada.IdSituacaoPaciente;
                ConBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }
            ctx.Consulta.Update(ConBuscada);
            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Update(novaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consultum ConBuscada = ctx.Consulta.Find(idConsulta);
            ctx.Consulta.Remove(ConBuscada);
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int idUsuario)
        {
            return ctx.Consulta
              .Select(c => new Consultum
              {
                  IdConsulta = c.IdConsulta,
                  DataConsulta = c.DataConsulta,
                  DescricaoConsulta = c.DescricaoConsulta,
                  IdPacienteNavigation = new Paciente
                  {
                      IdUsuario = c.IdPacienteNavigation.IdUsuario,
                      IdPaciente = c.IdPacienteNavigation.IdPaciente,
                      NomePaciente = c.IdPacienteNavigation.NomePaciente,
                      DataNascimento = c.IdPacienteNavigation.DataNascimento,
                      Rg = c.IdPacienteNavigation.Rg,
                  },
                  IdMedicoNavigation = new Medico
                  {
                      IdUsuario = c.IdMedicoNavigation.IdUsuario,
                      IdMedico = c.IdMedicoNavigation.IdMedico,
                      NomeMedico = c.IdMedicoNavigation.NomeMedico,
                      IdEspecialidadeMedicaNavigation = new Especialidade
                      {
                          IdEspecialidadeMedica = c.IdMedicoNavigation.IdEspecialidadeMedicaNavigation.IdEspecialidadeMedica,
                          TipoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeMedicaNavigation.TipoEspecialidade
                      },
                  },
                  IdSituacaoPacienteNavigation = new SituacaoPaciente
                  {
                      IdSituacaoPaciente = c.IdSituacaoPacienteNavigation.IdSituacaoPaciente,
                      Avaliacao = c.IdSituacaoPacienteNavigation.Avaliacao
                  }
              })
                .Where(c => c.IdMedicoNavigation.IdUsuario == idUsuario || c.IdPacienteNavigation.IdUsuario == idUsuario)
                .ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta
                .Select(c => new Consultum()
                {
                    IdConsulta = c.IdConsulta,
                    IdMedico = c.IdMedico,
                    IdSituacaoPaciente = c.IdSituacaoPaciente,
                    IdPaciente = c.IdPaciente,
                    DataConsulta = c.DataConsulta,
                    DescricaoConsulta = c.DescricaoConsulta,
                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Rg = c.IdPacienteNavigation.Rg,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdEspecialidadeMedicaNavigation = new Especialidade
                        {
                            IdEspecialidadeMedica = c.IdMedicoNavigation.IdEspecialidadeMedicaNavigation.IdEspecialidadeMedica
                        },

                        IdClinicaNavigation = new Clinica
                        {
                            IdClinica = c.IdMedicoNavigation.IdClinicaNavigation.IdClinica,
                            Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                            NomeClinica = c.IdMedicoNavigation.IdClinicaNavigation.NomeClinica,
                            RazaoVisita = c.IdMedicoNavigation.IdClinicaNavigation.RazaoVisita
                        }
                    },
                    IdSituacaoPacienteNavigation = new SituacaoPaciente
                    {
                        IdSituacaoPaciente = c.IdSituacaoPacienteNavigation.IdSituacaoPaciente,
                        Avaliacao = c.IdSituacaoPacienteNavigation.Avaliacao
                    }
                })
                .ToList();
        }
    }
}