using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjectBancoItau.API.Controllers
{
    public class UsuarioApiController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioApiController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }
        // GET: api/UsuarioApi
        public IEnumerable<Usuario> Get()
        {
            var usuariosList = _usuarioApp.BuscaTodosUsuarios();
            return usuariosList;
        }

        // GET: api/UsuarioApi/5
        public Usuario Get(int id)
        {
            var usuario = _usuarioApp.BuscaUsuarioPorID(id);
            return usuario;
          //  return "value";
        }

        // POST: api/UsuarioApi
        public void Post(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Login) && string.IsNullOrEmpty(usuario.Senha)) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                    _usuarioApp.InserirUsuario(usuario);
            }
           
        }

        // PUT: api/UsuarioApi/5
        public void Put(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Login) && string.IsNullOrEmpty(usuario.Senha)) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _usuarioApp.AtualizarUsuario( usuario);

            }
        }

        // DELETE: api/UsuarioApi/5
        public void Delete(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarioApp.BuscaUsuarioPorID(id);
            _usuarioApp.DeletarUsuario(usuario); //deleta o usuário

        }
    }
}
