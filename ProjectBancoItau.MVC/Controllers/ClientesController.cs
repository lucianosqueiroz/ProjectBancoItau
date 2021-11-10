using AutoMapper;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
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

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }


        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            // var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetBuscaTodosClientes());
            List<Cliente> clientes = await _clienteApp.GetBuscaTodosClientes();
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.BuscaClientePorId(id));
            return View(clienteViewModel);
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
                }
                

               // return RedirectToAction("Index",ModelError);
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.BuscaClientePorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);

                if (clienteDomain.IsValid()) //verifica se os dados do cliente são válidos (cpf no caso)
                {
                    _clienteApp.AtualizarCliente(clienteDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {

            var cliente = _clienteApp.BuscaClientePorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirmed(int id)
        {
            var cliente = _clienteApp.BuscaClientePorId(id);
            _clienteApp.DeletarCliente(cliente);

            return RedirectToAction("Index");
        }
    }
}
