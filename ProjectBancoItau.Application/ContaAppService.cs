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
    public class ContaAppService : IContaAppService
    {
        //private readonly IContaService _contaService;
        HttpClient _contaHttpClient = new HttpClient();
        private readonly IEmailService _emailAppService;

        public ContaAppService(IEmailService emailAppService)
        {
            _emailAppService = emailAppService;
            _contaHttpClient.BaseAddress = new Uri("http://localhost:63454/");
            _contaHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AtualizarConta(Conta conta)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("http://localhost:63454/api/conta/PutSaldo"),
                Content = new StringContent(JsonConvert.SerializeObject(conta), Encoding.UTF8, "application/json")
            };
            var response = _contaHttpClient.SendAsync(request);
        }

        public async Task<Conta> ContaListaCliente(int? idConta)
        {
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta?idConta=" + idConta);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Conta>(dados);
            }
            return new Conta();

            // return _contaService.ContaListaCliente(idConta);
        }

        public void DeletarConta(Conta conta)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:63454/api/conta/"),
                Content = new StringContent(JsonConvert.SerializeObject(conta), Encoding.UTF8, "application/json")
            };
            var response = _contaHttpClient.SendAsync(request);

            //_contaService.DeletarConta(conta);
        }

        public void InserirConta(Conta conta)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:63454/api/conta/"),
                Content = new StringContent(JsonConvert.SerializeObject(conta), Encoding.UTF8, "application/json")
            };
            var response = _contaHttpClient.SendAsync(request);


            //_contaService.InserirConta(conta);
        }

        public async Task<List<Conta>> ContasListar()
        {
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Conta>>(dados);
            }
            return new List<Conta>();

            //return _contaService.ContasListar();
        }


        public  void AtualizarSaldoConta(int idConta, decimal saldo)
        {
            Conta conta = new Conta()
            {
                IdConta = idConta,
                Saldo = saldo
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("http://localhost:63454/api/conta/PutSaldo"),
                Content = new StringContent(JsonConvert.SerializeObject(conta), Encoding.UTF8, "application/json")
            };
            var response = _contaHttpClient.SendAsync(request);
        }

        public void EnviaEmail(Conta contaOrigem, Conta contaDestino)
        {
           /* Cliente clienteOrigem = new Cliente();
            Cliente clienteDestino = new Cliente();

            clienteOrigem = _h

            _emailAppService.Enviar()*/
        }

        public async Task<Conta> BuscaContaPeloIdCliente(int? idCliente)
        {
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta/" + idCliente);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Conta>(dados);
            }
            return new Conta();
            //return _contaService.BuscaContaPeloIdCliente(idCliente);
        }

        public async Task<Conta> ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia)
        {
            
   
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta?numeroConta=" + numeroConta+"&numeroAgencia=" + numeroAgencia);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Conta>(dados);
            }

            return new Conta();
            // return _contaService.ContaListaClienteNumeroContaAgencia(numeroConta, numeroAgencia);
        }

        public async Task<Conta> ContaListaClientePorNumConta(int? numConta)
        {
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta/" + numConta);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Conta>(dados);
            }

            return new Conta();
        }

        public async Task<List<Conta>> ContaListaPorAgencia(int? nAgencia)
        {
            HttpResponseMessage response = await _contaHttpClient.GetAsync("api/conta/" + nAgencia);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Conta>>(dados);
            }

            return new List<Conta>();

        }

    } 
}
