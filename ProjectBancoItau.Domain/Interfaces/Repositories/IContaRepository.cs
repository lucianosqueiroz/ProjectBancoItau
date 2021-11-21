using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Interfaces.Repositories
{ 

    public interface IContaRepository 
    {
        List<Conta> ContasListar();
        List<Conta> ContaListaPorAgencia(int? nAgencia);
        Conta ContaListaCliente(int? idConta);//busca a conta pelo registro dela
        Conta BuscaContaPeloIdCliente(int? idCliente);
        Conta ContaListaClientePorNumConta(int? numConta);
        void InserirConta(Conta conta);
        Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia);
        void DeletarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void AtualizarSaldoConta(int idConta, decimal saldo);


    }
}
