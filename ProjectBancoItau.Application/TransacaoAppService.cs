using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class TransacaoAppService :ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoAppService(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        public void AtualizarTransacao(Transacao transacao)
        {
            _transacaoService.AtualizarTransacao(transacao);
        }

        public IEnumerable<Transacao> BuscaTodosTransacaos()
        {
            return _transacaoService.BuscaTodosTransacaos();
        }

        public void DeletarTransacao(Transacao transacao)
        {
            _transacaoService.DeletarTransacao(transacao);
        }

        public void InserirTransacao(Transacao transacao)
        {
            _transacaoService.InserirTransacao(transacao);
        }

        public Transacao BuscaTransacaoPorId(int id)
        {
            return _transacaoService.BuscaTransacaoPorId(id);
        }
    }

}
