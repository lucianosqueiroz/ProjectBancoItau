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
    public class TransacaoService :  ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public void AtualizarTransacao(Transacao transacao)
        {
            _transacaoRepository.AtualizarTransacao(transacao);
        }

        public IEnumerable<Transacao> BuscaTodosTransacaos()
        {
            return _transacaoRepository.BuscaTodosTransacaos();
        }


        public void DeletarTransacao(Transacao transacao)
        {
            _transacaoRepository.DeletarTransacao(transacao);
        }

        public void InserirTransacao(Transacao transacao)
        {
            _transacaoRepository.InserirTransacao(transacao);
        }

        public Transacao BuscaTransacaoPorId(int id)
        {
            return _transacaoRepository.BuscaTransacaoPorId(id);
        }
    }
}
