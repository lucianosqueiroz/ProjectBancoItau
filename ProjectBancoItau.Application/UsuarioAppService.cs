using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            :base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
             _usuarioService.AtualizarUsuario(usuario);
        }

        public IEnumerable<Usuario> BuscaTodosUsuarios()
        {
            return  _usuarioService.BuscaTodosUsuarios();
        }

        public IEnumerable<Usuario> BuscaTodosUsuariosGerentes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> BuscaTodosUsuariosGerentes(IEnumerable<Usuario> usuarios)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscaUsuarioPorID(int? idUsuario )
        {
            return _usuarioService.BuscaUsuarioPorID(idUsuario);
        }

        public void DeletarUsuario(Usuario usuario)
        {
            _usuarioService.DeletarUsuario(usuario);
        }

        public void InserirUsuario(Usuario usuario)
        {
            _usuarioService.InserirUsuario(usuario);
        }

        public Usuario ListaUsuarioPorLogin(string login)
        {
            return _usuarioService.ListaUsuarioPorLogin(login);
        }

    }
}
