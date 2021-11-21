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
    public class ContaController : ApiController
    {
        private readonly IContaRepository _contaRepository;

        public ContaController(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        // GET: api/conta
        [HttpGet]
        public  IHttpActionResult Get()
        {
            var contas =  _contaRepository.ContasListar();

            if (contas.Count() > 0)
            {
                return Ok(contas);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
            }
        }

        /* [HttpGet]
         [Route("GetGerentes")]
         public IHttpActionResult GetGerentes()
         {
             var contasList = _contaRepository.BuscaTodosContasGerentes();

             if (contasList.Count() > 0)
             {
                 return Ok(contasList);
             }
             else
             {
                 return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
             }
         }*/

        // GET: api/Conta/5
        [HttpGet]
        public  IHttpActionResult GetContaListaCliente(int idConta)//localia cliente pelo id da conta
        {
            Conta conta =  _contaRepository.ContaListaCliente(idConta);
            if (conta.IdConta != 0)
            {
                return Ok(conta);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
            }
        }


        [HttpGet]
        public IHttpActionResult GetBuscaContaPeloIdCliente(int idCliente)//localiza conta pelo id do cliente
        {
            var conta = _contaRepository.BuscaContaPeloIdCliente(idCliente);
            if (conta.IdConta != 0)
            {
                return Ok(conta);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
            }
        }
        [HttpGet]
        public IHttpActionResult GetContaListaPorAgencia(int nAgencia)//localiza contas de uma determinada agencia
        {
            var listConta = _contaRepository.ContaListaPorAgencia(nAgencia);
            if (listConta!=null)
            {
                return Ok(listConta);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
            }
        }
        [HttpGet]
        public  IHttpActionResult GetContaListaClienteContaAgencia(int numeroConta, int numeroAgencia)//localiza conta pelo numero da conta e agencia
        {
            var conta =  _contaRepository.ContaListaClienteNumeroContaAgencia(numeroConta, numeroAgencia);
            if (conta.IdConta != 0)
            {
                return Ok(conta);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
            }
        }



        /*  [HttpGet]
          [Route("GetLogin")]
          public IHttpActionResult GetLogin(string login)
          {
              var conta = _contaRepository.ListaContaPorLogin(login);
              if (conta.IdConta != 0)
              {
                  return Ok(conta);
              }
              else
              {
                  return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
              }
          }*/

        // POST: api/conta
        public IHttpActionResult Post(Conta conta)
        {
            if (conta.IdConta != 0 ) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _contaRepository.InserirConta(conta);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível cadastrar o usuário.");

        }

        // PUT: api/conta/5
        public IHttpActionResult Put(Conta conta)
        {
            if (conta.IdConta != 0) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                if (conta.idCliente!=0)// se o Id do cliente for diferente de 0, pela lógica criado o sistema alterará toda a estrutura do objeto conta
                {
                    _contaRepository.AtualizarConta(conta);
                    return Ok();
                }
                else //caso não tenha id do cliente, só será atualizado o saldo
                {
                    _contaRepository.AtualizarSaldoConta(conta.IdConta,conta.Saldo);
                    return Ok();
                }
                
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível atualizar o usuário.");
        }
        [HttpPatch]
        [Route("PutSaldo")]
        public IHttpActionResult PutSaldo(Conta conta)//atualizar saldo
        {
            if (conta.IdConta != 0) //se a senha nem o login do usuário não for em branco, insira ele no banco
            {
                _contaRepository.AtualizarSaldoConta(conta.IdConta,conta.Saldo);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Não foi possível atualizar o usuário.");
        }

        // DELETE: api/conta/5
        public IHttpActionResult Delete([FromBody] Conta conta)
        {
            conta = _contaRepository.BuscaContaPeloIdCliente(conta.IdConta);
            if (conta.IdConta != 0) //se o cliente for cadastrado
            {
                _contaRepository.DeletarConta(conta);
                return Ok();
            }
            return Content(HttpStatusCode.NotFound, "Conta não encontrado.");
        }
    }
}

