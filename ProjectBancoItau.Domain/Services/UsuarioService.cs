using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);
        }

        public IEnumerable<Usuario> BuscaTodosUsuarios()
        {
            return _usuarioRepository.BuscaTodosUsuarios();
        }

        public IEnumerable<Usuario> BuscaTodosUsuariosGerentes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> BuscaTodosUsuariosGerentes(IEnumerable<Usuario>usuarios)
        {
            return usuarios.Where(c => c.UsuarioGerente(c));
        }

        public Usuario BuscaUsuarioPorID(int? idUsuario)
        {
            return _usuarioRepository.BuscaUsuarioPorID(idUsuario);
        }

        public void DeletarUsuario(Usuario usuario)
        {
            _usuarioRepository.DeletarUsuario(usuario);
        }

        public void InserirUsuario(Usuario usuario)
        {
            _usuarioRepository.InserirUsuario(usuario);
        }

        public Usuario ListaUsuarioPorLogin(string login)
        {
            return _usuarioRepository.ListaUsuarioPorLogin(login);
        }
    }
}
