using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectBancoItau.API.Controllers
{
    public class ContasController : ApiController
    {
        // GET: api/Contas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contas/5
        public void Delete(int id)
        {
        }
    }
}
