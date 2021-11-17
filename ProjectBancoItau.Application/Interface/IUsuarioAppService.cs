using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<List<Usuario>> BuscaTodosUsuarios();
        Task<List<Usuario>> BuscaTodosUsuariosGerentes();
        Task<Usuario> ListaUsuarioPorLogin(string login);
        Task<Usuario> BuscaUsuarioPorID(int? idUsuario);
        void InserirUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}
