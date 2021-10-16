using SP_MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Repositories
{
    interface ConsultaRepository : IConsultaRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void AdicionarDecrição(int idConsulta, Consultum ConsultaComDescricao)
        {
            Consultum ConsultaBuscada = BuscarPorId(idConsulta);

            if (ConsultaComDescricao.DescricaoConsulta != null)
            {
                ConsultaBuscada.DescricaoConsulta = ConsultaComDescricao.DescricaoConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public void Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPorId(idConsulta);

            if (consultaAtualizada.IdPaciente != null && consultaAtualizada.IdMedico != null && consultaAtualizada.IdSituacaoPaciente != null && consultaAtualizada.DataConsulta != null)
            {
                ConsultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                ConsultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                ConsultaBuscada.IdSituacaoPaciente = consultaAtualizada.IdSituacaoPaciente;
                ConsultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Cancela(int idConsulta, string status)
        {
            Consultum consultaMudar = BuscarPorId(idConsulta);

            switch (status)
            {
                case "1":
                    consultaMudar.IdSituacaoPaciente = 1;
                    break;

                case "2":
                    consultaMudar.IdSituacaoPaciente = 2;
                    break;

                case "3":
                    consultaMudar.IdSituacaoPaciente = 3;
                    break;

                default:
                    consultaMudar.IdSituacaoPaciente = consultaMudar.IdSituacaoPaciente;
                    break;
            }

            ctx.Consulta.Update(consultaMudar);

            ctx.SaveChanges();

        }

        public void Deletar(int idConsulta)
        {
            Consultum consultaBuscada = BuscarPorId(idConsulta);

            ctx.Consulta.Remove(consultaBuscada);

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
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario
                        }
                    },
                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdEspecialidadeMedicaNavigation = new Especialidade
                        {
                            TipoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade
                        },

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario
                        }
                    },
                    IdSituacaoPacienteNavigation = new SituacaoPaciente
                    {
                        Avaliacao = c.IdSituacaoNavigation.Situacao1
                    }
                })
                .Where(c => c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario == idUsuario || c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario == idUsuario).ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta
                .Select(c => new Consultum
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    DescricaoConsulta = c.DescricaoConsulta,
                    IdPacienteNavigation = new Paciente
                    {
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdEspecialidadeMedicaNavigation = new Especialidade
                        {
                            TipoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade
                        },
                    },
                    IdSituacaoPacienteNavigation = new SituacaoPaciente
                    {
                        Avaliacao = c.IdSituacaoNavigation.Situacao1
                    }
                }).ToList();
        }
    }
}
