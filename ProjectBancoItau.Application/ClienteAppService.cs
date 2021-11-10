using Newtonsoft.Json;
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

       

        public void AtualizarCliente(Cliente cliente)
        {
          //  _clienteService.AtualizarCliente(cliente);
        }

        public async Task<List<Cliente>> GetBuscaTodosClientes()
        {
            HttpResponseMessage response = await _clienteHttpCliente.GetAsync("api/cliente");
            if(response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }

            return new List<Cliente>();
        }


        public Cliente BuscaClientePorCPF(string cpfCliente)
        {
            return null;
           // return _clienteService.BuscaClientePorCPF(cpfCliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
           
            // _clienteService.DeletarCliente(cliente);
        }

        public void InserirCliente(Cliente cliente)
        {

           // _clienteService.InserirCliente(cliente);
        }

        public Cliente BuscaClientePorId(int id)
        {
            return null;
        }

        public Cliente ListaClienteNome(string nomeClienteConta)
        {
            return null;
        }
    }

}
