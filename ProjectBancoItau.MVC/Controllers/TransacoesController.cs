using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly ITransacaoAppService _transacaoApp;

        public TransacoesController(ITransacaoAppService transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }


        // GET: Transacao
        public ActionResult Index()
        {
            var transacaoViewModel = Mapper.Map<IEnumerable<Transacao>, IEnumerable<TransacaoViewModel>>(_transacaoApp.BuscaTodosTransacaos());
            return View(transacaoViewModel);
        }
        /*
        
        // GET: Transacao/Details/5
        public ActionResult Details(int id)
        {
            var transacaoViewModel = Mapper.Map<Transacao, TransacaoViewModel>(_transacaoApp.BuscaTransacaoPorId(id));
            return View(transacaoViewModel);
        }
        /*
        // GET: Transacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacao/Create
        [HttpPost]
        public ActionResult Create(TransacaoViewModel transacao)
        {
            if (ModelState.IsValid)
            {
                var usuairoDomain = Mapper.Map<TransacaoViewModel, Transacao>(transacao);
                _transacaoApp.InserirTransacao(usuairoDomain);

                return RedirectToAction("Index");
            }

            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public ActionResult Edit(int id)
        {
            var transacao = _transacaoApp.BuscaTransacaoPorId(id);
            var transacaoViewModel = Mapper.Map<Transacao, TransacaoViewModel>(transacao);

            return View(transacaoViewModel);
        }

        // POST: Transacao/Edit/5
        [HttpPost]
        public ActionResult Edit(TransacaoViewModel transacao)
        {
            if (ModelState.IsValid)
            {
                var transacaoDomain = Mapper.Map<TransacaoViewModel, Transacao>(transacao);
                _transacaoApp.AtualizarTransacao(transacaoDomain);

                return RedirectToAction("Index");
            }
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public ActionResult Delete(int id)
        {

            var transacao = _transacaoApp.BuscaTransacaoPorId(id);
            var transacaoViewModel = Mapper.Map<Transacao, TransacaoViewModel>(transacao);

            return View(transacaoViewModel);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirmed(int id)
        {
            var transacao = _transacaoApp.BuscaTransacaoPorId(id);
            _transacaoApp.DeletarTransacao(transacao);

            return RedirectToAction("Index");
        }*/
    }
}
