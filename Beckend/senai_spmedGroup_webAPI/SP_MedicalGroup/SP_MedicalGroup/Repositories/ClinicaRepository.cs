using SP_MedicalGroup.Domains;
using SP_MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.IdEndereco != null && clinicaAtualizada.NomeClinica!= null && clinicaAtualizada.Cnpj != null && clinicaAtualizada.RazaoVisita != null && clinicaAtualizada.ClinicaAberta != null && clinicaAtualizada.ClinicaFechada!= null)
            {
                clinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
                clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicaBuscada.RazaoVisita = clinicaAtualizada.RazaoVisita;
                clinicaBuscada.ClinicaAberta = clinicaAtualizada.ClinicaAberta;
                clinicaBuscada.ClinicaFechada = clinicaAtualizada.ClinicaFechada;

            }

            ctx.Clinicas.Update(clinicaBuscada);

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
                        NomeRua = c.IdEnderecoNavigation.Rua,
                        Numero = c.IdEnderecoNavigation.Numero,
                        Bairro = c.IdEnderecoNavigation.Bairro,
                        Cidade = c.IdEnderecoNavigation.Cidade,
                    },
                    NomeClinica = c.NomeFantasia,
                    Cnpj = c.Cnpj,
                    RazaoVisita = c.RazaoSocial,
                    ClinicaAberta = c.HorarioAbertura,
                    ClinicaFechada = c.HorarioFechamento,
                    Medicos = c.Medicos
                }).ToList();
        }
    }
}
