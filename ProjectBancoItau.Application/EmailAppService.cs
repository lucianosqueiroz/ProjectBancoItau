using Newtonsoft.Json;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application
{
    public class EmailAppService : IEmailAppService
    {
        HttpClient _emailHttpClient = new HttpClient();

        public EmailAppService()
        {

            _emailHttpClient.BaseAddress = new Uri("http://localhost:63454/");
            _emailHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void Enviar(Email email)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:63454/api/email/"),
                Content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json")
            };
            var response = _emailHttpClient.SendAsync(request);
        }
    }
}
