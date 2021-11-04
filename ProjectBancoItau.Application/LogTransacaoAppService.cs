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
    public class LogTransacaoAppService : AppServiceBase<LogTransacao>, ILogTransacaoAppService
    {
        private readonly ILogTransacaoService _logTransacaoService;

        public LogTransacaoAppService(ILogTransacaoService logTransacaoService)
            : base(logTransacaoService)
        {
            _logTransacaoService = logTransacaoService;
        }

        public void AtualizarLogTransacao(LogTransacao logTransacao)
        {
            _logTransacaoService.AtualizarLogTransacao(logTransacao);
        }

        

        public void DeletarLogTransacao(LogTransacao logTransacao)
        {
            _logTransacaoService.DeletarLogTransacao(logTransacao);
        }

        public IEnumerable<LogTransacao> ExtratoResumido(int? idCliente, int? idConta, int? idTrans, DateTime dataInicial, DateTime dataFinal)
        {
            return _logTransacaoService.ExtratoResumido(idCliente, idConta, idTrans, dataInicial, dataFinal);
        }

        public void InserirLogTransacao(LogTransacao logTransacao)
        {
            _logTransacaoService.InserirLogTransacao(logTransacao);
        }

        public LogTransacao LogTransacaoListaConta(int? idConta)
        {
            return _logTransacaoService.LogTransacaoListaConta(idConta);
        }

        public IEnumerable<LogTransacao> LogTransacaosListar()
        {
            return _logTransacaoService.LogTransacaosListar();
        }
    }

}
