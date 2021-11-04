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
    public class ContaService : ServiceBase<Conta>, IContaService
    {
        private readonly IContaRepository _contaService;

        public ContaService(IContaRepository contaRepository)
            : base(contaRepository)
        {
            _contaService = contaRepository;
        }

        public void AtualizarConta(Conta conta)
        {
            _contaService.AtualizarConta(conta);
        }

        public Conta ContaListaCliente(int? idConta)
        {
            return _contaService.ContaListaCliente(idConta);
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
            return _contaService.ContasListar();
        }

        public Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia)
        {
            return _contaService.ContaListaClienteNumeroContaAgencia(numeroConta,  numeroAgencia);
        }

        public void AtualizarSaldoConta(int idConta, decimal saldo)
        {
            _contaService.AtualizarSaldoConta(idConta, saldo);
        }

        public Conta BuscaContaPeloIdCliente(int? idCliente)
        {
           return _contaService.BuscaContaPeloIdCliente(idCliente);
        }

        public Conta ContaListaClientePorNumConta(int? numConta)
        {
            return _contaService.ContaListaClientePorNumConta(numConta);
        }

        public IEnumerable<Conta> ContaListaPorAgencia(int? nAgencia)
        {
            return _contaService.ContaListaPorAgencia(nAgencia);
        }
    }
}
