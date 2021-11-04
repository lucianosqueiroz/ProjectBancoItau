﻿using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class ContaAppService : AppServiceBase<Conta>, IContaAppService
    {
        private readonly IContaService _contaService;

        public ContaAppService(IContaService contaService)
            : base(contaService)
        {
            _contaService = contaService;
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


        public void AtualizarSaldoConta(int idConta, decimal saldo)
        {
            _contaService.AtualizarSaldoConta(idConta, saldo);
        }

        public Conta BuscaContaPeloIdCliente(int? idCliente)
        {
            return _contaService.BuscaContaPeloIdCliente(idCliente);
        }

        public Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia)
        {
            return _contaService.ContaListaClienteNumeroContaAgencia(numeroConta, numeroAgencia);
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
