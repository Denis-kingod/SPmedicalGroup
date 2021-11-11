
using spmedical.Contexts;
using spmedical.Domains;
using spmedical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            if (medicoAtualizado.IdUsuario != null && medicoAtualizado.IdEspecialidadeMedica != null && medicoAtualizado.IdClinica != null && medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
                medicoBuscado.IdEspecialidadeMedica = medicoAtualizado.IdEspecialidadeMedica;
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novomedico)
        {
            ctx.Medicos.Add(novomedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}