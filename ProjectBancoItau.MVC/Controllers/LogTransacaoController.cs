using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Controllers
{
    public class LogTransacaoController : Controller
    {
        private readonly ILogTransacaoAppService _logTransacaoApp;
        private readonly IClienteAppService _clienteApp;
        private readonly IContaAppService _contaApp;
        private readonly ITransacaoAppService _transacaoApp;

        public LogTransacaoController(ILogTransacaoAppService logTransacaoApp, IClienteAppService clienteApp, IContaAppService contaApp, ITransacaoAppService  transacaoApp)
        {
            _logTransacaoApp = logTransacaoApp;
            _clienteApp = clienteApp;
            _contaApp = contaApp;
            _transacaoApp = transacaoApp;
        }


        //GET: Log transacao  SAQUE
        public ActionResult Saque()

        {

            return View();

        }

        //POST: Log transacao SAQUE
        [HttpPost]
        public ActionResult Saque(int numeroConta)
        {/*
            var dadosConta = _contaApp.ContaListaClienteNumeroConta(numeroConta);
            var cliente = new Cliente();


            cliente = _clienteApp.BuscaClientePorId(dadosConta.idCliente);*/

            return View();
        }

        /*

                // GET: LogTransacao
        public ActionResult Index()
        //List<LogTransacao> LogTransacaos = new List<LogTransacao>();
        {
            var logTransacaoViewModel = Mapper.Map<IEnumerable<LogTransacao>, IEnumerable<LogTransacaoViewModel>>(_logTransacaoApp.LogTransacaosListar());
            List<ClienteLogTransacaoViewModel> listaLogTransacaoClienteViewModel = new List<ClienteLogTransacaoViewModel>();

            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva logTransacao)
            foreach (var clienteViewModel in logTransacaoViewModel)
            {
                Cliente cliente = new Cliente();

                cliente = _clienteApp.BuscaClientePorId(Convert.ToInt32(clienteViewModel.idCliente)); //pega o proprietário de cada logTransacao da Lista logTransacaoViewModel

                ClienteLogTransacaoViewModel clienteLogTransacaoViewModel = new ClienteLogTransacaoViewModel
                {//criação de objeto view model contendo dados das logTransacaos com seus respectivos clientes 
                    idCliente = cliente.idCliente,
                    Cpf = cliente.Cpf,
                    Nome = cliente.Nome,
                    IdLogTransacao = clienteViewModel.IdLogTransacao,
                    NLogTransacao = clienteViewModel.NLogTransacao,
                    CDigito = clienteViewModel.CDigito,
                    NAgencia = clienteViewModel.NAgencia,
                    ADigito = clienteViewModel.ADigito,
                    Senha = clienteViewModel.Senha,
                    Saldo = clienteViewModel.Saldo

                };

                listaLogTransacaoClienteViewModel.Add(clienteLogTransacaoViewModel);

            }
            return View(listaLogTransacaoClienteViewModel);
        }

        // GET: LogTransacao/Details/5
        public ActionResult Details(int id)
        {
            var logTransacaoViewModel = Mapper.Map<LogTransacao, LogTransacaoViewModel>(_logTransacaoApp.LogTransacaoListaCliente(id));//lista determinada logTransacao pelo Id da logTransacao


            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva logTransacao)
            Cliente cliente = new Cliente();

            cliente = _clienteApp.BuscaClientePorId(Convert.ToInt32(logTransacaoViewModel.idCliente)); //pega o proprietário de cada logTransacao da Lista logTransacaoViewModel

            ClienteLogTransacaoViewModel clienteLogTransacaoViewModel = new ClienteLogTransacaoViewModel
            {//criação de objeto view model contendo dados das logTransacaos com seus respectivos clientes 
                idCliente = cliente.idCliente,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                IdLogTransacao = logTransacaoViewModel.IdLogTransacao,
                NLogTransacao = logTransacaoViewModel.NLogTransacao,
                CDigito = logTransacaoViewModel.CDigito,
                NAgencia = logTransacaoViewModel.NAgencia,
                ADigito = logTransacaoViewModel.ADigito,
                Senha = logTransacaoViewModel.Senha,
                Saldo = logTransacaoViewModel.Saldo

            };


            return View(clienteLogTransacaoViewModel);
        }

        // GET: LogTransacao/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome");
            return View();
        }

        // POST: LogTransacao/Create
        [HttpPost]
        public ActionResult Create(ClienteLogTransacaoViewModel logTransacao)
        {
            if (ModelState.IsValid)
            {
                var logTransacaoDomain = Mapper.Map<ClienteLogTransacaoViewModel, LogTransacao>(logTransacao);
                _logTransacaoApp.InserirLogTransacao(logTransacaoDomain);

                return RedirectToAction("Index");
            }

            return View(logTransacao);
        }

        // GET: LogTransacao/Edit/5
        public ActionResult Edit(int id)
        {
            var logTransacao = _logTransacaoApp.LogTransacaoListaCliente(id);
            var clienteLogTransacaoViewModel = Mapper.Map<LogTransacao, ClienteLogTransacaoViewModel>(logTransacao);

            ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome", clienteLogTransacaoViewModel.idCliente);

            return View(clienteLogTransacaoViewModel);
        }

        // POST: LogTransacao/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteLogTransacaoViewModel clienteLogTransacao)
        {
            if (ModelState.IsValid)
            {
                var logTransacaoDomain = Mapper.Map<ClienteLogTransacaoViewModel, LogTransacao>(clienteLogTransacao);
                _logTransacaoApp.AtualizarLogTransacao(logTransacaoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome", clienteLogTransacao.idCliente);
            return View(clienteLogTransacao);
        }

        // GET: LogTransacao/Delete/5
        public ActionResult Delete(int id)
        {

            var logTransacao = _logTransacaoApp.LogTransacaoListaCliente(id);
            var logTransacaoViewModel = Mapper.Map<LogTransacao, LogTransacaoViewModel>(logTransacao);

            return View(logTransacaoViewModel);
        }

        // POST: LogTransacao/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirmed(int id)
        {
            var logTransacao = _logTransacaoApp.LogTransacaoListaCliente(id);
            _logTransacaoApp.DeletarLogTransacao(logTransacao);

            return RedirectToAction("Index");
        }*/

    }
}