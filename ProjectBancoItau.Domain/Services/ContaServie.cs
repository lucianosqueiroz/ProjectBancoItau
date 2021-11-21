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
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaService;

        public ContaService(IContaRepository contaRepository)
        {
            _contaService = contaRepository;
        }

        public void AtualizarConta(Conta conta)
        {
            _contaService.AtualizarConta(conta);
        }

        public Conta ContaListaCliente(int? idConta)
        {
            return null; //_contaService.ContaListaCliente(idConta);
        }

        public void DeletarConta(Conta conta)
        {
            _contaService.DeletarConta(conta);
        }

        public void InserirConta(Conta conta)
        {
            _contaService.InserirConta(conta);
        }

        public IEnumerable<Conta> ContasListar()
        {
            return null;//_contaService.ContasListar();
        }

        public Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia)
        {
            return null;//_contaService_contaService.ContaListaClienteNumeroContaAgencia(numeroConta,  numeroAgencia);
        }

        public void AtualizarSaldoConta(int idConta, decimal saldo)
        {
            _contaService.AtualizarSaldoConta(idConta, saldo);
        }

        public Conta BuscaContaPeloIdCliente(int? idCliente)
        {
           return null;//_contaService.BuscaContaPeloIdCliente(idCliente);
        }

        public Conta ContaListaClientePorNumConta(int? numConta)
        {
            return null;//_contaService.ContaListaClientePorNumConta(numConta);
        }

        public IEnumerable<Conta> ContaListaPorAgencia(int? nAgencia)
        {
            return null;//_contaService.ContaListaPorAgencia(nAgencia);
        }
    }
}
