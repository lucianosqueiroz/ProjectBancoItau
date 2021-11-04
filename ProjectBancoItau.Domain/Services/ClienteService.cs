using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Services
{
    public class ClienteService :  IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            
        {
            _clienteRepository = clienteRepository;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _clienteRepository.AtualizarCliente(cliente);
        }

        public IEnumerable<Cliente> BuscaTodosClientes()
        {
            return _clienteRepository.BuscaTodosClientes();
        }



        public Cliente BuscaClientePorCPF(string cpfCliente)
        {
            return _clienteRepository.BuscaClientePorCPF(cpfCliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            _clienteRepository.DeletarCliente(cliente);
        }

        public void InserirCliente(Cliente cliente)
        {
            _clienteRepository.InserirCliente(cliente);
        }

        public Cliente BuscaClientePorId(int id)
        {
            return _clienteRepository.BuscaClientePorId(id);
        }

        public Cliente ListaClienteNome(string nomeClienteConta)
        {
            return _clienteRepository.ListaClienteNome(nomeClienteConta);
        }
    }
}