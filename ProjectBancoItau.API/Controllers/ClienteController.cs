using ProjectBancoItau.Domain.Conexao;
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
    public class ClienteController : ApiController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;
        public ClienteController(IClienteRepository clienteRepository, IContaRepository contaRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
        }
        // GET: api/Cliente
        public IHttpActionResult Get()
        {
            var clientes =_clienteRepository.BuscaTodosClientes();

            if (clientes.Count()>0)
            {
                return Ok(_clienteRepository.BuscaTodosClientes());
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Cliente não encontrado.");
            }
        }

        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
            var cliente = _clienteRepository.BuscaClientePorId(id);
            if (!string.IsNullOrEmpty(cliente.Cpf))
            {
                return Ok(_clienteRepository.BuscaClientePorId(id));
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Cliente não encontrado.");
            }
            
        }

        // POST: api/Cliente
        public IHttpActionResult Post(Cliente cliente)
        {
            if (cliente.IsValid()) //verifica se os dados do cliente são válidos (cpf no caso)
                {
                   _clienteRepository.InserirCliente(cliente);
                   return Ok() ;
                }
            return Content(HttpStatusCode.NotFound, "Cpf inválido");
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(Cliente cliente)
        {
            if (cliente.IsValid()) //verifica se os dados do cliente são válidos (cpf no caso)
            {
                _clienteRepository.AtualizarCliente(cliente);
                return Ok();
                
            }
            return Content(HttpStatusCode.NotFound, "Cpf inválido");
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete([FromBody]Cliente cliente)
        {
            cliente = _clienteRepository.BuscaClientePorCPF(cliente.Cpf);
            if (!string.IsNullOrEmpty(cliente.Cpf)) //se o cliente for cadastrado
            {
                Conta conta = new Conta();
                conta = _contaRepository.BuscaContaPeloIdCliente(cliente.idCliente);
                if (conta.idCliente == 0 ) // caso o cliente tenha aluguma conta ligada a ele
                {
                    _clienteRepository.DeletarCliente(cliente);
                    return Ok();
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Cliente possui contas vinculadas.");
                }
                
            }
            return Content(HttpStatusCode.NotFound, "Cliente não encontrado.");
        }
    }
}
