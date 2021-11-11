using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using ProjectBancoItau.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectBancoItau.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly HttpClient _clienteHttpCliente;
        public ClienteAppService(HttpClient clienteHttpCliente)
        {
            _clienteHttpCliente = clienteHttpCliente;

            _clienteHttpCliente.BaseAddress = new Uri("http://localhost:63454/");
            _clienteHttpCliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public  void AtualizarCliente(Cliente cliente)
        {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("http://localhost:63454/api/cliente/"),
                    Content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json")
                };
            var response =  _clienteHttpCliente.SendAsync(request);
        }

        public async Task<List<Cliente>> GetBuscaTodosClientes()
        {
            HttpResponseMessage response = await _clienteHttpCliente.GetAsync("api/cliente");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }


            return new List<Cliente>();
        }


        public async Task<Cliente> BuscaClientePorCPF(string cpfCliente)
        {
            HttpResponseMessage response = await _clienteHttpCliente.GetAsync("api/cliente/" + cpfCliente);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Cliente>(dados);
            }
            return new Cliente();
        }

        public void DeletarCliente(Cliente cliente)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:63454/api/cliente/"),
                Content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json")
            };
            var response =  _clienteHttpCliente.SendAsync(request);
            

            
        }

        public  void InserirCliente(Cliente cliente)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:63454/api/cliente/"),
                Content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json")
            };
            var response =  _clienteHttpCliente.SendAsync(request);
        }

        public async Task<Cliente> BuscaClientePorId(int id)
        {
            HttpResponseMessage response = await _clienteHttpCliente.GetAsync("api/cliente/"+id);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Cliente>(dados);
            }
            return new Cliente();
        }

        public Cliente ListaClienteNome(string nomeClienteConta)
        {
           return null;
        }
    }

}
