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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var usuario = _usuarioRepository.BuscaUsuarioPorID(id);
            if (usuario.IdUsuario != 0 )
            {
                return Ok(usuario);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Usuario não encontrado.");
            }
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
        public IHttpActionResult Post(Usuario usuario)
        {
            if (usuario.Login != null  && usuario.Senha!= null) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _usuarioRepository.InserirUsuario(usuario);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível cadastrar o usuário.");

        }

        // PUT: api/usuario/5
        public IHttpActionResult Put(Usuario usuario)
        {
            if (usuario.Login != null && usuario.Senha != null) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _usuarioRepository.AtualizarUsuario(usuario);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível atualizar o usuário.");
        }

        // DELETE: api/usuario/5
        public IHttpActionResult Delete([FromBody] Usuario usuario)
        {
            usuario = _usuarioRepository.BuscaUsuarioPorID(usuario.IdUsuario);
            if (usuario.IdUsuario != 0) //se o cliente for cadastrado
            {
                _usuarioRepository.DeletarUsuario(usuario);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Usuario não encontrado.");
        }
    }
}
