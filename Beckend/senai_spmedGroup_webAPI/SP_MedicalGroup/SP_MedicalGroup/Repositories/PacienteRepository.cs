using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            if (pacienteAtualizado.IdUsuario != null && pacienteAtualizado.IdEndereco != null && pacienteAtualizado.NomePaciente != null  && pacienteAtualizado.Telefone != null && pacienteAtualizado.Rg != null)
            {
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
                pacienteBuscado.IdEndereco = pacienteAtualizado.IdEndereco;
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }
            else
            {
            }

            ctx.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novopaciente)
        {
            ctx.Add(novopaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}