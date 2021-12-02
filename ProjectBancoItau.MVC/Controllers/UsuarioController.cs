using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.Extensions;
using ProjectBancoItau.MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectBancoItau.Services;

namespace ProjectBancoItau.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        public ActionResult LogarUsuario()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            var usuarioDomain2 = await _usuarioApp.ListaUsuarioPorLogin(usuarioDomain.Login);
            var senhaDescript = new Senha();
            usuarioDomain2.Senha = senhaDescript.Descriptografar(usuarioDomain2.Senha); //descriptografando a senha digitada pelo usuário para fazer comparação com banco


            if (usuarioDomain2.Senha == usuarioViewModel.Senha && usuarioDomain2.Gerente == true)//validar senha onde usuarioViewModel.senha é a senha digitada pelo usuário e usuarioViewModel2.senha, é a registrada em banco. O usuario tbm devera ser gerente
            {
                return Redirect("/Contas/BuscaClienteConta/");
            }
            if (usuarioDomain2.Login == null)
            {
                this.AddNotification("Usuário não encontrado.", NotificationType.ERROR);
                return View();
            }
            if (usuarioDomain2.Gerente == false)
            {
                this.AddNotification("Você não tem permissão de gerente.", NotificationType.ERROR);
                return View();
            }

            else
            {

                this.AddNotification("Senha inválida.", NotificationType.ERROR);
                return View(); //senha errada
            }


        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            List<Usuario> usuario = await _usuarioApp.BuscaTodosUsuarios();
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(usuario);
            return View(usuarioViewModel);
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var usuario = await _usuarioApp.BuscaUsuarioPorID(id);
            if (usuario.IdUsuario != 0)
            {
                var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
                return View(usuarioViewModel);
            }
            else
            {
                this.AddNotification("Agência, conta ou senha inválida.", NotificationType.ERROR);
                return View();
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                var senhaCript = new Senha();
                usuarioDomain.Senha = senhaCript.Criptografar(usuarioDomain.Senha);
                _usuarioApp.InserirUsuario(usuarioDomain);
                this.AddNotification("Usuario cadastrado com sucesso.", NotificationType.SUCCESS);
                return RedirectToAction("Index");

            }
            this.AddNotification("Erro ao cadastrar o usuario.", NotificationType.ERROR);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var usuario = await _usuarioApp.BuscaUsuarioPorID(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {

                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
                _usuarioApp.AtualizarUsuario(usuarioDomain);
                this.AddNotification("Usuário editado com sucesso.", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("Erro ao editar o usuário.", NotificationType.ERROR);
            return View(usuarioViewModel);
        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var usuario = await _usuarioApp.BuscaUsuarioPorID(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteComfirmed(int id)
        {
            var usuario = await _usuarioApp.BuscaUsuarioPorID(id);
            _usuarioApp.DeletarUsuario( usuario);
            this.AddNotification("Usuário excluído com sucesso..", NotificationType.SUCCESS);

            return RedirectToAction("Index");
        }
    }

}
