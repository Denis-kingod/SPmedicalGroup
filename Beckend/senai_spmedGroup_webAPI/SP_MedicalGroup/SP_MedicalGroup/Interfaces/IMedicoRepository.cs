using SP_MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();

        Medico BuscarPorId(int idMedico);

        void Cadastrar(Medico novomedico);

        void Atualizar(int idMedico, Medico medicoAtualizado);

        void Deletar(int idMedico);
    }
}