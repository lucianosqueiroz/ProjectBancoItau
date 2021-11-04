using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using ProjectBancoItau.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _clienteService.AtualizarCliente(cliente);
        }

        public IEnumerable<Cliente> BuscaTodosClientes()
        {
            return _clienteService.BuscaTodosClientes();
        }


        public Cliente BuscaClientePorCPF(string cpfCliente)
        {
            return _clienteService.BuscaClientePorCPF(cpfCliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            _clienteService.DeletarCliente(cliente);
        }

        public void InserirCliente(Cliente cliente)
        {
            _clienteService.InserirCliente(cliente);
        }

        public Cliente BuscaClientePorId(int id)
        {
            return _clienteService.BuscaClientePorId(id);
        }

        public Cliente ListaClienteNome(string nomeClienteConta)
        {
           return _clienteService.ListaClienteNome(nomeClienteConta);
        }
    }

}
