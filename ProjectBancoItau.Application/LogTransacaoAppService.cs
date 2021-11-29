using Newtonsoft.Json;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class LogTransacaoAppService : ILogTransacaoAppService
    {
        HttpClient _logTransacaoHttpClient = new HttpClient();
        private readonly ILogTransacaoService _logTransacaoService;

        public LogTransacaoAppService()
        {
            _logTransacaoHttpClient.BaseAddress = new Uri("http://localhost:63454/");
            _logTransacaoHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AtualizarLogTransacao(LogTransacao logTransacao)
        {
            _logTransacaoService.AtualizarLogTransacao(logTransacao);
        }

        

        public void DeletarLogTransacao(LogTransacao logTransacao)
        {
            _logTransacaoService.DeletarLogTransacao(logTransacao);
        }

        public async Task<List<LogTransacao>> ExtratoResumido(int? idCliente, int? idConta, int? idTrans, DateTime dataInicial, DateTime dataFinal)
        {
            String dataInicialString = dataInicial.ToString("yyyy-MM-dd");
            String dataFinalString = dataFinal.ToString("yyyy-MM-dd");
            string linkEndPoint = "api/logtransacao/GetExtratoResumido?idCliente=" + idCliente + "&idConta=" + idConta + "&idTrans="+idTrans+"&dataInicial=" + dataInicialString + "&dataFinal=" + dataFinalString;
            HttpResponseMessage response = await _logTransacaoHttpClient.GetAsync(linkEndPoint);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<LogTransacao>>(dados);
            }
            return new List<LogTransacao>();
        }
        public async Task<List<LogTransacao>> ExtratoCompleto(int? idCliente, int? idConta, DateTime dataInicial, DateTime dataFinal)
        {
            String dataInicialString = dataInicial.ToString("yyyy-MM-dd");
            String dataFinalString = dataFinal.ToString("yyyy-MM-dd");
            string linkEndPoint = "api/LogTransacao/GetExtratoCompleto?idCliente=" + idCliente + "&idConta=" + idConta + "&dataInicial=" + dataInicialString + "&dataFinal=" + dataFinalString;
            HttpResponseMessage response = await _logTransacaoHttpClient.GetAsync(linkEndPoint);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<LogTransacao>>(dados);
            }
            return new List<LogTransacao>();
        }
        public void InserirLogTransacao(LogTransacao logTransacao)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:63454/api/LogTransacao/"),
                Content = new StringContent(JsonConvert.SerializeObject(logTransacao), Encoding.UTF8, "application/json")
            };
            var response = _logTransacaoHttpClient.SendAsync(request);
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
