using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Infra.Data.Repositorios;
using ProjectBancoItau.MVC.Extensions;
using ProjectBancoItau.MVC.ViewModels;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult LogarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuarioViewModel2 = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioApp.ListaUsuarioPorLogin(usuarioViewModel.Login));
                                                                                                                       
            if (usuarioViewModel2.Senha == usuarioViewModel.Senha && usuarioViewModel2.Gerente==true)//validar senha onde usuarioViewModel.senha é a senha digitada pelo usuário e usuarioViewModel2.senha, é a registrada em banco. O usuario tbm devera ser gerente
            {
                return Redirect("/Contas/BuscaClienteConta/");
            }
            if (usuarioViewModel2.Gerente ==false)
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
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioApp.BuscaTodosUsuarios());
            return View(usuarioViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int?  id)
        {
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioApp.BuscaUsuarioPorID(id));
            return View(usuarioViewModel);
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
                var usuairoDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _usuarioApp.InserirUsuario(usuairoDomain);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _usuarioApp.BuscaUsuarioPorID(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _usuarioApp.AtualizarUsuario(usuarioDomain);

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {

            var usuario = _usuarioApp.BuscaUsuarioPorID(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirmed(int id)
        {
            var usuario = _usuarioApp.BuscaUsuarioPorID(id);
            _usuarioApp.DeletarUsuario(usuario);

            return RedirectToAction("Index");
        }
    }
}
