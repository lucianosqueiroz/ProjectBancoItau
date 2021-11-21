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
        // GET: api/logTransacao
        [HttpGet]
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

        // GET: api/LogTransacao/5
        [HttpGet]
        public IHttpActionResult Get(int conta)
        {
            var logTransacao = _logTransacaoRepository.LogTransacaoListaConta(conta);
            if (logTransacao.IdLogTransacao != 0)
            {
                return Ok(logTransacao);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "LogTransacao não encontrado.");
            }
        }

        [HttpGet]
        

        // POST: api/logTransacao
        public IHttpActionResult Post(LogTransacao logTransacao)
        {
            if (logTransacao.IdConta != 0 ) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _logTransacaoRepository.InserirLogTransacao(logTransacao);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível cadastrar o usuário.");

        }

        // PUT: api/logTransacao/5
        public IHttpActionResult Put(LogTransacao logTransacao)
        {
            if (logTransacao.IdConta != 0) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _logTransacaoRepository.AtualizarLogTransacao(logTransacao);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível atualizar o usuário.");
        }
        // DELETE: api/logTransacao/5
        public IHttpActionResult Delete([FromBody] LogTransacao logTransacao)
        {
            logTransacao = _logTransacaoRepository.LogTransacaoListaConta(logTransacao.IdConta);
            if (logTransacao.IdLogTransacao != 0) //se existir log
            {
                _logTransacaoRepository.DeletarLogTransacao(logTransacao);
                return Ok();

            }
            return Content(HttpStatusCode.NotFound, "Log não encontrado.");
        }


    }
}
