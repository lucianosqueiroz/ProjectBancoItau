using ProjectBancoItau.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectBancoItau.API.Controllers
{
    public class TransacaoController : ApiController
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoController(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        public IHttpActionResult Get()
        {
            var transacaos = _transacaoRepository.BuscaTodosTransacaos();

            if (transacaos.Count() > 0)
            {
                return Ok(transacaos);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Transações não encontradas.");
            }
        }
    }
}
