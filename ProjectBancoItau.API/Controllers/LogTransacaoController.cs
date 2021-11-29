using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectBancoItau.API.Controllers
{
    public class LogTransacaoController : ApiController
    {
        private readonly ILogTransacaoRepository _logTransacaoRepository;
        private readonly IContaRepository _contaRepository;

        public LogTransacaoController(ILogTransacaoRepository logTransacaoRepository, IContaRepository contaRepository)
        {
            _logTransacaoRepository = logTransacaoRepository;
            _contaRepository = contaRepository;
        }
        // GET: api/LogTransacao
        public IHttpActionResult Get()
        {
            var logTransacaos = _logTransacaoRepository.LogTransacaosListar();

            if (logTransacaos.Count() > 0)
            {
                return Ok(logTransacaos);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "LogTransacao não encontrado.");
            }
        }

        [HttpGet, Route("api/LogTransacao/GetExtratoResumido")]
        public IHttpActionResult GetExtratoResumido(int? idCliente, int? idConta, int? idTrans, DateTime dataInicial, DateTime dataFinal)// extrato completo
        {
            var logTransacao = _logTransacaoRepository.ExtratoResumido(idCliente, idConta, idTrans, dataInicial, dataFinal);
            if (logTransacao.Count() > 0)
            {
                return Ok(logTransacao);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "LogTransacao não encontrado.");
            }
        }
        [HttpGet, Route("api/LogTransacao/GetExtratoCompleto")]
        public IHttpActionResult GetExtratoCompleto(int? idCliente, int? idConta, DateTime dataInicial, DateTime dataFinal)// extrato completo
        {
            var logTransacao = _logTransacaoRepository.ExtratoCompleto(idCliente, idConta, dataInicial, dataFinal);

            if (logTransacao.Count() > 0)
            {
                return Ok(logTransacao);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "LogTransacao não encontrado.");
            }
        }
        // GET: api/LogTransacao/5
        /* public string Get(int id)
         {
             return "value";
         }*/

        // POST: api/LogTransacao
        public IHttpActionResult Post(LogTransacao logTransacao)
        {
            if (logTransacao != null) //verifica se os dados do cliente são válidos (cpf no caso)
            {
                _logTransacaoRepository.InserirLogTransacao(logTransacao);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Transação não gravada.");
        }

        // PUT: api/LogTransacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogTransacao/5
        public void Delete(int id)
        {
        }
    }
}
