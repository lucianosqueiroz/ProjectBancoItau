using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> BuscaTodosUsuarios();
        IEnumerable<Usuario> BuscaTodosUsuariosGerentes();
        Usuario ListaUsuarioPorLogin(string login);
        Usuario BuscaUsuarioPorID(int? idUsuario);
        void InserirUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);

    }
}
