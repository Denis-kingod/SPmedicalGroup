using Microsoft.AspNetCore.Http;
using SP_MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novausuario);

        void Atualizar(int idUsuario, Usuario usuarioAtualizada);

        void Deletar(int idUsuario);
        Usuario Login(string email, object senha);
    }
}
