using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectBancoItau.API.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: api/usuario
        [HttpGet]
        public IHttpActionResult Get()
        {
            var usuarios = _usuarioRepository.BuscaTodosUsuarios();

            if (usuarios.Count() > 0)
            {
                return Ok(usuarios);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Usuario não encontrado.");
            }
        }

        [HttpGet]
        [Route("GetGerentes")]
        public IHttpActionResult GetGerentes()
        {
            var usuariosList = _usuarioRepository.BuscaTodosUsuariosGerentes();

            if (usuariosList.Count() > 0)
            {
                return Ok(usuariosList);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Usuario não encontrado.");
            }
        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            var usuario = _usuarioRepository.BuscaUsuarioPorID(id);
            return usuario;
            //  return "value";
        }

        [HttpGet]
        [Route("GetLogin")]
        public IHttpActionResult GetLogin(string login)
        {
            var usuario = _usuarioRepository.ListaUsuarioPorLogin(login);
            if (usuario.IdUsuario != 0)
            {
                return Ok(usuario);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Usuario não encontrado.");
            }
        }

        // POST: api/usuario
        public void Post(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Login) && string.IsNullOrEmpty(usuario.Senha)) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _usuarioRepository.InserirUsuario(usuario);
            }

        }

        // PUT: api/usuario/5
        public void Put(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Login) && string.IsNullOrEmpty(usuario.Senha)) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _usuarioRepository.AtualizarUsuario(usuario);

            }
        }

        // DELETE: api/usuario/5
        public void Delete(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarioRepository.BuscaUsuarioPorID(id);
            _usuarioRepository.DeletarUsuario(usuario); //deleta o usuário

        }

    }
}
