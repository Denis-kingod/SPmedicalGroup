using Microsoft.AspNetCore.Http;
using spmedical.Contexts;
using spmedical.Domains;
using spmedical.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace spmedical.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            if (usuarioAtualizado.IdTipoUsuario != null && usuarioAtualizado.Email != null && usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novousuario)
        {
            ctx.Add(novousuario);

            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int idUsuario)
        {
            string nomeNovo = idUsuario.ToString() + ".png";

            string caminho = Path.Combine("Perfil", nomeNovo);

            //analisa se o caminho existe
            if (File.Exists(caminho))
            {
                //recupera o array de bytes
                byte[] bytesArquivo = File.ReadAllBytes(caminho);

                //converte em base64
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario Login(string email, object senha)
        {
            throw new NotImplementedException();
        }

        public void SalvarPerfilDir(IFormFile foto, int idUsuario)
        {
            string nomeNovo = idUsuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("Perfil", nomeNovo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}