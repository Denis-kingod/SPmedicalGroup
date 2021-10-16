using SP_MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Interfaces
{
        interface IConsultaRepository
        {
           
            List<Consultum> ListarTodas();

            Consultum BuscarPorId(int idConsulta);

            void Cadastrar(Consultum novaConsulta);

            void Atualizar(int idConsulta, Consultum consultaAtualizada);

            void Deletar(int idConsulta);

            List<Consultum> ListarMinhas(int idUsuario);

            void AdicionarDecrição(int idConsulta, Consultum ConsultaComDescricao);

            void Cancela(int idConsulta, string status);
        }
    }
