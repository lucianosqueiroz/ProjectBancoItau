using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Interface
{
    public interface IContaAppService
    {
        Task<List<Conta>> ContasListar();
        Task<List<Conta>> ContaListaPorAgencia(int? nAgencia);
        Task<Conta> ContaListaCliente(int? idConta);
        Task<Conta> ContaListaClientePorNumConta(int? numConta);
        Task<Conta> BuscaContaPeloIdCliente(int? idCliente);
        void InserirConta(Conta conta);
        Task<Conta> ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia);
        void DeletarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void AtualizarSaldoConta(int idConta, decimal saldo);
    }
}
