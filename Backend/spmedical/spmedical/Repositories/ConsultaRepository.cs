
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
            return ctx.Consulta.ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta
            .Include(e => e.IdPacienteNavigation)
            .Include(e => e.IdMedicoNavigation)
            .Include(e => e.IdSituacaoPacienteNavigation)
            .ToList();
        }

    }
}