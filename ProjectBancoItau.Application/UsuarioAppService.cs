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
using Newtonsoft.Json;

namespace ProjectBancoItau.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        HttpClient _usuarioHttpClient = new HttpClient();
        //private readonly HttpClient _usuarioHttpClient;
        public UsuarioAppService()
        {
            //_usuarioHttpClient = usuarioHttpClient;
            _usuarioHttpClient.BaseAddress = new Uri("http://localhost:63454/");
            _usuarioHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("http://localhost:63454/api/usuario/"),
                Content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json")
            };
            var response = _usuarioHttpClient.SendAsync(request);
        }

        public async Task<List<Usuario>> BuscaTodosUsuarios()
        {
            HttpResponseMessage response = await _usuarioHttpClient.GetAsync("api/usuario");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }


            return new List<Usuario>();
        }

        public async Task<List<Usuario>> BuscaTodosUsuariosGerentes()
        {
            HttpResponseMessage response = await _usuarioHttpClient.GetAsync("api/usuario");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }
            return new List<Usuario>();
        }



        public async Task<Usuario> BuscaUsuarioPorID(int? idUsuario)
        {
            HttpResponseMessage response = await _usuarioHttpClient.GetAsync("api/usuario/" + idUsuario);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Usuario>(dados);
            }
            return new Usuario();
        }

        public void DeletarUsuario(Usuario usuario)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:63454/api/usuario/"),
                Content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json")
            };
            var response = _usuarioHttpClient.SendAsync(request);
        }

        public void InserirUsuario(Usuario usuario)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:63454/api/usuario/"),
                Content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json")
            };
            var response = _usuarioHttpClient.SendAsync(request);
        }

        public async Task<Usuario> ListaUsuarioPorLogin(string login)
        {


            HttpResponseMessage response = await _usuarioHttpClient.GetAsync("api/usuario/getlogin?login=" + login);
            var dados = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Usuario>(dados);
            }
            return new Usuario();


        }

    }
}
