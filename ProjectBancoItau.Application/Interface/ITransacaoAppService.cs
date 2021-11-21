using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Interface
{
    public interface ITransacaoAppService
    {
        Task<List<Transacao>> BuscaTodosTransacaos();
        Task<Transacao> BuscaTransacaoPorId(int id);
        void InserirTransacao(Transacao transacao);
        void DeletarTransacao(Transacao transacao);
        void AtualizarTransacao(Transacao transacao);
    }
}
