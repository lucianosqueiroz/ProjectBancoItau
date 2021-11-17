using ProjectBancoItau.Application.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Application.Model
{
    public class HomeApplication: BaseApplication
    {

        public HomeApplication() : base("http://localhost:63454/")
        {
        }

       // public HttpResponseMessage Get() => _httpClient.GetAsync("Get").Result;

        //public HttpResponseMessage Post(HomeModel home) => _httpClient.PostAsJsonAsync("Post", home).Result;
    }
}

