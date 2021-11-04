using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Interface
{
    public interface ILogTransacaoAppService: IAppServiceBase<LogTransacao>
    {
        IEnumerable<LogTransacao> LogTransacaosListar();
        //LogTransacao LogTransacaoListaCliente(int? numeroLogTransacao);
        IEnumerable<LogTransacao> ExtratoResumido(int? idCliente, int? idConta, int? idTrans, DateTime dataInicial, DateTime dataFinal);
        LogTransacao LogTransacaoListaConta(int? idConta);
        void InserirLogTransacao(LogTransacao logTransacao);
        void DeletarLogTransacao(LogTransacao logTransacao);
        void AtualizarLogTransacao(LogTransacao logTransacao);
    }
}
