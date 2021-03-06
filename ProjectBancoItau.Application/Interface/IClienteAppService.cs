using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Interface
{
    public interface IClienteAppService
    {
        Task<List<Cliente>> GetBuscaTodosClientes();
        Cliente ListaClienteNome(string nomeClienteConta);
        Task<Cliente> BuscaClientePorId(int id);
        Task<Cliente> BuscaClientePorCPF(string cpfCliente);
        void InserirCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
    }
}
