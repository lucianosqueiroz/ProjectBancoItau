using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.Extensions;
using ProjectBancoItau.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IContaAppService _contaApp;

        public ClientesController(IClienteAppService clienteApp, IContaAppService contaApp)
        {
            _clienteApp = clienteApp;
            _contaApp = contaApp;
        }


        // GET: Cliente
        [HttpGet, ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            //var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.BuscaTodosClientes());

            List<Cliente> clientes = await _clienteApp.GetBuscaTodosClientes();
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientes);
            return View(clienteViewModel);
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _clienteApp.BuscaClientePorId(id);

            if (cliente.idCliente != 0)
            {
                var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
                return View(clienteViewModel);
            }
            else
            {
                this.AddNotification("Agência, conta ou senha inválida.", NotificationType.ERROR);
                return View();
            }

        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                if (clienteDomain.IsValid()) //verifica se os dados do cliente são válidos (cpf no caso)
                {
                    _clienteApp.InserirCliente(clienteDomain);
                    this.AddNotification("Cliente cadastrado com sucesso.", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }
            this.AddNotification("Erro ao cadastrar o cliente.", NotificationType.ERROR);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _clienteApp.BuscaClientePorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {

                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

                if (clienteDomain.IsValid()) //verifica se os dados do cliente são válidos (cpf no caso)
                {
                    _clienteApp.AtualizarCliente(clienteDomain);
                    this.AddNotification("Cliente editado com sucesso..", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }
            this.AddNotification("Erro ao editar o cliente.", NotificationType.ERROR);
            return View(clienteViewModel);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _clienteApp.BuscaClientePorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteComfirmed(int id)
        {
            var cliente = _clienteApp.BuscaClientePorId(id);
            var conta = new Conta();
            conta = _contaApp.BuscaContaPeloIdCliente(id);

            if (conta.IdConta != 0) //caso cliente tenha alguma conta vinculada, não é permitido deletar o cliente. 
            {
                this.AddNotification("Cliente não pode ser excluído pois possui conta vinculada.", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
            else
            {
                _clienteApp.DeletarCliente(await cliente);
                this.AddNotification("Cliente excluído com sucesso..", NotificationType.SUCCESS);
                return RedirectToAction("Index");

            }

            
        }
    }
}
