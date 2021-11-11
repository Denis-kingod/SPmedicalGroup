using spmedical.Contexts;
using spmedical.Domains;
using spmedical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.IdEndereco != null && clinicaAtualizada.NomeClinica != null && clinicaAtualizada.Cnpj != null && clinicaAtualizada.RazaoVisita != null && clinicaAtualizada.ClinicaAberta != null && clinicaAtualizada.ClinicaFechada != null)
            {
                ClinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
                ClinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
                ClinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                ClinicaBuscada.RazaoVisita = clinicaAtualizada.RazaoVisita;
                ClinicaBuscada.ClinicaAberta = clinicaAtualizada.ClinicaAberta;
                ClinicaBuscada.ClinicaFechada = clinicaAtualizada.ClinicaFechada;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas
                .Select(c => new Clinica
                {
                    IdClinica = c.IdClinica,
                    IdEnderecoNavigation = new Endereco
                    {
                        NomeRua = c.IdEnderecoNavigation.NomeRua,
                        Numero = c.IdEnderecoNavigation.Numero,
                        Bairro = c.IdEnderecoNavigation.Bairro,
                        Cidade = c.IdEnderecoNavigation.Cidade,
                    },
                    NomeClinica = c.NomeClinica,
                    Cnpj = c.Cnpj,
                    RazaoVisita = c.RazaoVisita,
                    ClinicaAberta = c.ClinicaAberta,
                    ClinicaFechada = c.ClinicaFechada,
                }).ToList();
        }
    }
}
