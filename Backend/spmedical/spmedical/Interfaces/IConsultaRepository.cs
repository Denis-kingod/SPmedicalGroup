using spmedical.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Interfaces
{
        interface IConsultaRepository
        {
           
            List<Consultum> ListarTodas();

            Consultum BuscarPorId(int idConsulta);

            void Cadastrar(Consultum novaConsulta);

            void Atualizar(int idConsulta, Consultum consultaAtualizada);

            void Deletar(int idConsulta);

            List<Consultum> ListarMinhas(int idUsuario);

        }
    }
