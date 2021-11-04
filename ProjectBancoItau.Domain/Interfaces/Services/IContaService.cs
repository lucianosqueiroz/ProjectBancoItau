using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Interfaces.Services
{
    public interface IContaService 
    {
        IEnumerable<Conta> ContasListar();
        IEnumerable<Conta> ContaListaPorAgencia(int? nAgencia);
        Conta ContaListaCliente(int? idConta);
        Conta ContaListaClientePorNumConta(int? numConta);
        Conta BuscaContaPeloIdCliente(int? idCliente);
        void InserirConta(Conta conta);
        Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia);
        void DeletarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void AtualizarSaldoConta(int idConta, decimal saldo);

    }
}
