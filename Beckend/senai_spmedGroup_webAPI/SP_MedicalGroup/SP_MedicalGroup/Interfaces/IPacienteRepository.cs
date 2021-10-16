using SP_MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();

        Paciente BuscarPorId(int idPaciente);

        void Cadastrar(Paciente novopaciente);

        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

        void Deletar(int idPaciente);
    }
}
