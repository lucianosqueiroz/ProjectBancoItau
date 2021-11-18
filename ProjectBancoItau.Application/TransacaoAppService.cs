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
    public class TransacaoAppService :ITransacaoAppService
    {
        //private readonly ITransacaoService _transacaoService;
        HttpClient _transacaoHttpClient = new HttpClient();

        public TransacaoAppService()
        {
            _transacaoHttpClient.BaseAddress = new Uri("http://localhost:63454/");
            _transacaoHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AtualizarTransacao(Transacao transacao)
        {
            //_transacaoService.AtualizarTransacao(transacao);
        }

        public async Task<List<Transacao>> BuscaTodosTransacaos()
        {
            HttpResponseMessage response = await _transacaoHttpClient.GetAsync("api/transacao");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Transacao>>(dados);
            }
            return new List<Transacao>();
        }

        public void DeletarTransacao(Transacao transacao)
        {
          //  _transacaoService.DeletarTransacao(transacao);
        }

        public void InserirTransacao(Transacao transacao)
        {
           // _transacaoService.InserirTransacao(transacao);
        }

        public Transacao BuscaTransacaoPorId(int id)
        {
            return null; //_transacaoService.BuscaTransacaoPorId(id);
        }

        
    }

}
