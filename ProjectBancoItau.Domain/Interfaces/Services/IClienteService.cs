using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> BuscaTodosClientes();
        Cliente ListaClienteNome(string nomeClienteConta);
        Cliente BuscaClientePorId(int id);
        Cliente BuscaClientePorCPF(string cpfCliente);
        void InserirCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);

    }
}
