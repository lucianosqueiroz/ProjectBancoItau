using AutoMapper;
using PagedList;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.Extensions;
using ProjectBancoItau.MVC.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContaAppService _contaApp;
        private readonly IClienteAppService _clienteApp;
        private readonly ITransacaoAppService _transacaoApp;
        private readonly ILogTransacaoAppService _logTransacaoApp;
        private readonly IEmailAppService _emailApp;

        public ContasController(IContaAppService contaApp, IClienteAppService clienteApp, ILogTransacaoAppService logTransacaoApp, ITransacaoAppService transacaoApp, IEmailAppService emailApp)
        {
            _contaApp = contaApp;
            _clienteApp = clienteApp;
            _transacaoApp = transacaoApp;
            _logTransacaoApp = logTransacaoApp;
            _emailApp = emailApp;
        }

        public ActionResult LogarContaCliente()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> LogarContaCliente(ContaViewModel contaViewModel)
        {
            var contaCliente = await _contaApp.ContaListaClienteNumeroContaAgencia(contaViewModel.NConta, contaViewModel.NAgencia);  //localizar objeto conta pelo numero da conta
                                                                                                                                     //validar senha
            if ((contaCliente.NConta == contaViewModel.NConta) && (contaCliente.Senha == contaViewModel.Senha))
            {
                return RedirectToAction("ClienteLogado", new { id = contaCliente.IdConta });//redireciona para a página com detalhes do cliente.
                //return Redirect("/Contas/ClienteLogado/" + contaCliente.IdConta); //redireciona para a página com detalhes do cliente.
            }
            else
            {
                this.AddNotification("Agência, conta ou senha inválida.", NotificationType.ERROR);
                return View();
            }

        }


        public async Task<ActionResult> ClienteLogado(int id)
        {

            var contaViewModel = Mapper.Map<Conta, ContaViewModel>(await _contaApp.ContaListaCliente(id));//lista determinada conta pelo Id da conta


            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva conta)
            Cliente cliente = new Cliente();

            cliente = await _clienteApp.BuscaClientePorId(Convert.ToInt32(contaViewModel.idCliente)); //pega o proprietário de cada conta da Lista contaViewModel

            ClienteContaViewModel clienteContaViewModel = new ClienteContaViewModel
            {//criação de objeto view model contendo dados das contas com seus respectivos clientes 
                idCliente = cliente.idCliente,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                IdConta = contaViewModel.IdConta,
                NConta = contaViewModel.NConta,
                CDigito = contaViewModel.CDigito,
                NAgencia = contaViewModel.NAgencia,
                ADigito = contaViewModel.ADigito,
                Senha = contaViewModel.Senha,
                Saldo = contaViewModel.Saldo

            };


            return View(clienteContaViewModel);
        }

        public ActionResult BuscaClienteConta()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> BuscaClienteConta(ClienteContaViewModel clienteContaViewModel)
        {
            //Preenchido somente o nome do cliente na busca.
            if (!string.IsNullOrEmpty(clienteContaViewModel.Nome) && clienteContaViewModel.NConta == 0 && clienteContaViewModel.NAgencia == 0) //pesquisa por cliente sem preenchimento dos campos conta e agencia
            {
                Cliente cliente = new Cliente();
                cliente.Nome = clienteContaViewModel.Nome;

                cliente = _clienteApp.ListaClienteNome(cliente.Nome);

                if (cliente.idCliente != 0)//se existe cliente cadastrado
                {
                    var clienteContaViewModel2 = new ClienteContaViewModel(); //objeto viewmodel com os dados atualizados do cliente e conta

                    clienteContaViewModel2 = clienteContaViewModel = Mapper.Map<Conta, ClienteContaViewModel>(await _contaApp.BuscaContaPeloIdCliente(cliente.idCliente));

                    clienteContaViewModel2.Nome = cliente.Nome;
                    clienteContaViewModel2.Cpf = cliente.Cpf;


                    return View("ResultBuscaClienteConta", clienteContaViewModel2);
                }
                else
                {
                    this.AddNotification("Não foi encontrado nenhum cliente cadastrado iniciado por " + clienteContaViewModel.Nome + ".", NotificationType.ERROR);
                    return View();

                }

            }


            //preenchido somente o numero da conta
            if (string.IsNullOrEmpty(clienteContaViewModel.Nome) && clienteContaViewModel.NConta != 0 && clienteContaViewModel.NAgencia == 0) //pesquisa por numero conta sem preenchimento dos campos conta e agencia
            {
                Conta conta = new Conta();
                Cliente cliente = new Cliente();

                conta = await _contaApp.ContaListaClientePorNumConta(clienteContaViewModel.NConta);
                if (conta.IdConta != 0) //se foi encontrado pelo menos uma conta, prosseguir com a pesquisa
                {
                    cliente = await _clienteApp.BuscaClientePorId(conta.idCliente);

                    ClienteContaViewModel clienteContaViewModel2 = new ClienteContaViewModel
                    {//criação de objeto view model2 contendo dados das contas com seus respectivos clientes 
                        idCliente = cliente.idCliente,
                        Cpf = cliente.Cpf,
                        Nome = cliente.Nome,
                        IdConta = conta.IdConta,
                        NConta = conta.NConta,
                        CDigito = conta.CDigito,
                        NAgencia = conta.NAgencia,
                        ADigito = conta.ADigito,
                        Senha = conta.Senha,
                        Saldo = conta.Saldo

                    };

                    return View("ResultBuscaClienteConta", clienteContaViewModel2);
                }
                else
                {
                    this.AddNotification("Não foi encontrado nenhuma conta de número " + clienteContaViewModel.NConta + " cadastrado no sistema.", NotificationType.ERROR);
                    return View();
                }

            }


            //preenchido somente numero agencia
            if (string.IsNullOrEmpty(clienteContaViewModel.Nome) && clienteContaViewModel.NConta == 0 && clienteContaViewModel.NAgencia != 0) //pesquisa por Agencia sem preenchimento dos campos conta e agencia
            {
                var contaViewModelLista = Mapper.Map<IEnumerable<Conta>, IEnumerable<ContaViewModel>>(await _contaApp.ContaListaPorAgencia(clienteContaViewModel.NAgencia));

                if (contaViewModelLista.Count() == 0)//se não encontrar nenhuma agência cadastrada
                {
                    this.AddNotification("Não existe agência de número " + clienteContaViewModel.NAgencia + " cadastra no sistema.", NotificationType.ERROR);
                    return View();
                }
                else // caso encontre agencia cadastrada gerar lista
                {
                    List<ClienteContaViewModel> listaContaClienteViewModel = new List<ClienteContaViewModel>();

                    //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva conta)
                    foreach (var clienteViewModel in contaViewModelLista)
                    {
                        Cliente cliente = new Cliente();

                        cliente = await _clienteApp.BuscaClientePorId(Convert.ToInt32(clienteViewModel.idCliente)); //pega o proprietário de cada conta da Lista contaViewModel

                        ClienteContaViewModel clienteContaViewModelNew = new ClienteContaViewModel
                        {//criação de objeto view model contendo dados das contas com seus respectivos clientes 
                            idCliente = cliente.idCliente,
                            Cpf = cliente.Cpf,
                            Nome = cliente.Nome,
                            IdConta = clienteViewModel.IdConta,
                            NConta = clienteViewModel.NConta,
                            CDigito = clienteViewModel.CDigito,
                            NAgencia = clienteViewModel.NAgencia,
                            ADigito = clienteViewModel.ADigito,
                            Senha = clienteViewModel.Senha,
                            Saldo = clienteViewModel.Saldo

                        };

                        listaContaClienteViewModel.Add(clienteContaViewModelNew);
                    }
                    return View("ListResultBuscaClienteConta", listaContaClienteViewModel);
                }


            }
            else
            {
                this.AddNotification("Preencha pelo menos um campo", NotificationType.ERROR);
                return View();
            }

        }

        public async Task<ActionResult> SacarDinheiro(int id)
        {

            var clienteContaViewModel = Mapper.Map<Conta, ClienteContaViewModel>(await _contaApp.ContaListaCliente(id));//lista determinada conta pelo Id da conta
            return View(clienteContaViewModel);


        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SacarDinheiro(ClienteContaViewModel clienteContaViewModel, decimal valorSaque)
        {
            var conta = Mapper.Map<Conta, ContaViewModel>(await _contaApp.ContaListaCliente(clienteContaViewModel.IdConta));//lista determinada conta pelo Id da conta


            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva conta)
            Cliente cliente = new Cliente();

            cliente = await _clienteApp.BuscaClientePorId(Convert.ToInt32(conta.idCliente)); //pega o proprietário de cada conta da Lista contaViewModel

            if (conta.Senha == clienteContaViewModel.Senha) //se a senha digitada na viewModel for igual a senha cadastrada no banco
            {
                if (valorSaque < conta.Saldo)
                {
                    conta.Saldo = conta.Saldo - valorSaque;

                    var logTransacao = new LogTransacao() //monta objeto com os dados da transação
                    {
                        IdConta = conta.IdConta,
                        IdCliente = cliente.idCliente,
                        IdTrans = 1, //id 1 para SAQUE, 2 para Depósito, 3 para Transferência.
                        ValorTrans = valorSaque,
                        DataTrans = DateTime.Now,

                    };
                    _contaApp.AtualizarSaldoConta(conta.IdConta, conta.Saldo); //atualiza saldo conta cliente
                    _logTransacaoApp.InserirLogTransacao(logTransacao); //salva os dados da transação banco
                    return RedirectToAction("ClienteLogado", new { id = clienteContaViewModel.IdConta });//redireciona para a página com detalhes do cliente
                }
                else
                {
                    this.AddNotification("Saldo insuficiente.", NotificationType.ERROR);
                    return View();
                }

            }


            return View();

        }
        public ActionResult Depositar()
        {


            return View();


        }

        [HttpPost]
        public async Task<ActionResult> Depositar(FormCollection form)
        {
            var conta = new Conta();

            conta.NConta = Convert.ToInt32(form["conta"]);
            conta.NAgencia = Convert.ToInt32(form["agencia"]);
            conta = await _contaApp.ContaListaClienteNumeroContaAgencia(conta.NConta, conta.NAgencia);
            var tipoDeposito = form["opcaoSelecionada"];
            var valorDeposito = Convert.ToDecimal(form["valor"]);

            if (conta.idCliente != 0) //se existir algum cliente com agencia e conta.
            {
                conta.Saldo = conta.Saldo + valorDeposito;
                _contaApp.AtualizarSaldoConta(conta.IdConta, conta.Saldo); //atualiza saldo no banco

                if (tipoDeposito == "dinheiro") //deposito em dinheiro
                {
                    var logTransacao = new LogTransacao() //monta objeto com os dados da transação
                    {
                        IdConta = conta.IdConta,
                        IdCliente = conta.idCliente,
                        IdTrans = 2, //id 2 para Depósito em dinheiro, 5 deposito em cheque, 6 doc, 7 ted.
                        ValorTrans = valorDeposito,
                        DataTrans = DateTime.Now,
                    };

                    _logTransacaoApp.InserirLogTransacao(logTransacao); //cria o registro da transação de depósito em banco
                    return RedirectToAction("ClienteLogado", new { id = conta.IdConta });//redireciona para a página com detalhes do cliente
                }

                if (tipoDeposito == "cheque") //deposito em cheque
                {
                    var logTransacao = new LogTransacao() //monta objeto com os dados da transação
                    {
                        IdConta = conta.IdConta,
                        IdCliente = conta.idCliente,
                        IdTrans = 5, //id 2 para Depósito em dinheiro, 5 deposito em cheque, 6 doc, 7 ted.
                        ValorTrans = valorDeposito,
                        DataTrans = DateTime.Now,
                    };

                    _logTransacaoApp.InserirLogTransacao(logTransacao); //cria o registro da transação de depósito em banco
                    return RedirectToAction("ClienteLogado", new { id = conta.IdConta });//redireciona para a página com detalhes do cliente
                    //return View();
                }
            }


            this.AddNotification("Agência ou conta inexistentes.", NotificationType.ERROR);
            return View();
        }

        public async Task<ActionResult> Transferencia(int id)
        {

            var clienteContaViewModel = Mapper.Map<Conta, ClienteContaViewModel>(await _contaApp.ContaListaCliente(id));//lista determinada conta pelo Id da conta
            return View(clienteContaViewModel);


        }

        [HttpPost]
        public async Task<ActionResult>  Transferencia(FormCollection form, ClienteContaViewModel origemClienteContaViewModel)
        {
            var contaOrigem = new Conta();
            var contaDestino = new Conta();

            contaDestino.NConta = Convert.ToInt32(form["conta"]);
            contaDestino.NAgencia = Convert.ToInt32(form["agencia"]);
            contaDestino = await _contaApp.ContaListaClienteNumeroContaAgencia(contaDestino.NConta, contaDestino.NAgencia); //localiza a conta de destino
            contaOrigem = await _contaApp.ContaListaCliente(origemClienteContaViewModel.IdConta); //localiza a conta de 

            Cliente clienteOrigem = new Cliente();
            Cliente clienteDestino = new Cliente();

            clienteOrigem = await _clienteApp.BuscaClientePorId(contaOrigem.idCliente);
            clienteDestino = await _clienteApp.BuscaClientePorId(contaDestino.idCliente);

            var tipoTransferencia = form["opcaoSelecionada"];
            var valorTransferencia = Convert.ToDecimal(form["valor"]);

            if (contaDestino.IdConta == 0)
            {
                this.AddNotification("Agência ou conta inexistentes.", NotificationType.ERROR);
                return View();
            }

            if (valorTransferencia > contaOrigem.Saldo)
            {

                this.AddNotification("O valor da transferência é maior que o valor do saldo em conta.", NotificationType.ERROR);
                return View();
            }
            else
            {
                if (contaOrigem.idCliente != contaDestino.idCliente && contaDestino.idCliente != 0) //para fazer ted e doc, a conta de origem deve ser diferente da conta de destino E a conta de destino deva existir no banco e consequentemente ter um cliente -> contaDestino.idCliente != 0.
                {

                    contaDestino.Saldo = contaDestino.Saldo + valorTransferencia;
                    _contaApp.AtualizarSaldoConta(contaDestino.IdConta, contaDestino.Saldo); //atualiza saldo no banco
                    Email emailContaDestino = new Email()//preparando corpo e-mail para o recebedor da transferência
                    {
                        de = clienteDestino.Email,
                        para = clienteDestino.Email,
                        assunto = "Transferência entre contas.",
                        mensagem = "Transferência realizada da conta " + contaOrigem.NConta + " - " + contaOrigem.CDigito + " para conta "+ contaDestino.NConta + 
                            " - " + contaDestino.CDigito + " no valor de R$" + valorTransferencia + ". Seu saldo atual é R$" + contaDestino.Saldo + "."
                    };
                    _emailApp.Enviar(emailContaDestino);//envio do email para o cliente de destino


                    contaOrigem.Saldo = contaOrigem.Saldo - valorTransferencia;
                    _contaApp.AtualizarSaldoConta(contaOrigem.IdConta, contaOrigem.Saldo); //atualiza saldo no banco
                    Email emailContaOrigem = new Email()//objeto email para ser enviado ao cliente de origem da transferência
                    {
                        de = clienteOrigem.Email,
                        para = clienteOrigem.Email,
                        assunto = "Transferência entre contas.",
                        mensagem = "Transferência realizada da conta " + contaOrigem.NConta + " - " + contaOrigem.CDigito + " para conta " + contaDestino.NConta +
                            " - " + contaDestino.CDigito + " no valor de R$" + valorTransferencia + ". Seu saldo atual é R$" + contaOrigem.Saldo + "."
                    };
                    _emailApp.Enviar(emailContaOrigem);//enviando o e-mail para o cliente de origem.

                    if (tipoTransferencia == "doc") //deposito em dinheiro
                    {
                        var logTransacaoContaDestino = new LogTransacao() //monta objeto com os dados da transação
                        {
                            IdConta = contaDestino.IdConta,
                            IdCliente = contaDestino.idCliente,
                            IdTrans = 6, //id 2 para Depósito em dinheiro, 5 deposito em cheque, 6 doc, 7 ted.
                            ValorTrans = valorTransferencia,
                            DataTrans = DateTime.Now,
                        };
                        var logTransacaoOrigem = new LogTransacao() //monta objeto com os dados da transação
                        {
                            IdConta = contaOrigem.IdConta,
                            IdCliente = contaOrigem.idCliente,
                            IdTrans = 6, //id 2 para Depósito em dinheiro, 5 deposito em cheque, 6 doc, 7 ted.
                            ValorTrans = valorTransferencia,
                            DataTrans = DateTime.Now,
                        };

                        _logTransacaoApp.InserirLogTransacao(logTransacaoContaDestino); //cria o registro da transação de depósito em banco
                        _logTransacaoApp.InserirLogTransacao(logTransacaoOrigem);
                        return RedirectToAction("ClienteLogado", new { id = contaOrigem.IdConta });
                        //return Redirect("/Contas/ClienteLogado/" + contaOrigem.IdConta);
                        //return View();
                    }

                    if (tipoTransferencia == "ted") //deposito em cheque
                    {
                        var logTransacaoContaDestino = new LogTransacao() //monta objeto com os dados da transação
                        {
                            IdConta = contaDestino.IdConta,
                            IdCliente = contaDestino.idCliente,
                            IdTrans = 7, //id 2 para Depósito em dinheiro, 3 deposito em cheque, 4 doc, 5 ted.
                            ValorTrans = valorTransferencia,
                            DataTrans = DateTime.Now,
                        };
                        var logTransacaoContaOrigem = new LogTransacao() //monta objeto com os dados da transação
                        {
                            IdConta = contaOrigem.IdConta,
                            IdCliente = contaOrigem.idCliente,
                            IdTrans = 7, //id 2 para Depósito em dinheiro, 3 deposito em cheque, 4 doc, 5 ted.
                            ValorTrans = valorTransferencia,
                            DataTrans = DateTime.Now,
                        };

                        _logTransacaoApp.InserirLogTransacao(logTransacaoContaDestino); //cria o registro da transação de transferencia relacionada na conta de destino
                        _logTransacaoApp.InserirLogTransacao(logTransacaoContaOrigem);// cria log da transação de transferencia na conta de origem


                        return RedirectToAction("ClienteLogado", new { id = contaOrigem.IdConta });
                    }

                }
            }


            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Extrato(int id)
        {

            var clienteContaTransLogTransViewModel = new ClienteContaTransLogTransViewModel(); //Mapper.Map<LogTransacao, ClienteContaTransLogTransViewModel>(await _transacaoApp.BuscaTodosTransacaos());
            var transacoes = _transacaoApp.BuscaTodosTransacaos();

            Conta conta = new Conta();
            conta = await  _contaApp.ContaListaCliente(id);

            Cliente cliente = new Cliente();
            cliente = await _clienteApp.BuscaClientePorId(conta.idCliente);
            string dadosConta = "Agência: " + conta.NAgencia + " - " + conta.ADigito + "    Conta: " + conta.NConta + " - " + conta.CDigito; // conta + agencia do cliente

            // ViewBag.Nconta = new SelectList(_transacaoApp.BuscaTodosTransacaos(), "idTRansacao", "Nome", clienteContaTransLogTransViewModel.IdTrans);
            ViewBag.nomeCliente = cliente.Nome;
            ViewBag.dadosConta = dadosConta; //imprime view os dados do cliente.
            ViewBag.idTrans = new SelectList(await _transacaoApp.BuscaTodosTransacaos(), "idTRansacao", "Nome", clienteContaTransLogTransViewModel.IdTrans);

            TempData["contaSelecinada"] = conta;
            TempData["clienteSelecionado"] = cliente;




            return View(clienteContaTransLogTransViewModel);


        }

        [HttpPost]

        public async Task<ActionResult> Extrato(ClienteContaTransLogTransViewModel clienteContaTransLogTransViewModel, DateTime dataInicial, DateTime dataFinal)
        {
            var conta = TempData["contaSelecinada"] as Conta;
            var cliente = TempData["clienteSelecionado"] as Cliente;


            //  var conta = new Conta();
            // conta = _contaApp.ContaListaCliente(clienteContaTransLogTransViewModel.IdConta);

            var transacao = new Transacao();
            transacao = await _transacaoApp.BuscaTransacaoPorId(clienteContaTransLogTransViewModel.IdTrans);//pega o tipo de transacao que será mostrado no extrato


            if (transacao.IdTransacao == 0)//opção de todas transações marcadas no listbox. Extrato Completo
            {

                var listTransacoesDomain = await _logTransacaoApp.ExtratoCompleto(conta.idCliente, conta.IdConta, dataInicial, dataFinal);
                var listClienteContaTransLogTransViewModel2 = Mapper.Map<List<LogTransacao>,
                   List<ClienteContaTransLogTransViewModel >>(listTransacoesDomain);
                var transcaoId = 0; //variável controle para não reliar select no banco toda hora
                foreach (var item in listClienteContaTransLogTransViewModel2)
                {
                    if (transcaoId != item.IdTrans)//se transacaoId for diferente do id do novo item, faça select novamente nas transações para ver o novo nome.
                    {
                        transacao = await _transacaoApp.BuscaTransacaoPorId(item.IdTrans);
                       
                    }
                    item.Transacao = transacao.Nome;
                    item.NConta = conta.NConta;
                    item.Transacao = transacao.Nome;
                    transcaoId = item.IdTrans;
                }

                if (conta.idCliente != 0)
                {
                    TempData["TempData_clienteContaTransLogTransViewModel"] = listClienteContaTransLogTransViewModel2;
                    return RedirectToAction("ListExtratoConta2");
                    // RedirectToAction("ListExtratoConta2", clienteContaTransLogTransViewModel2);
                }
                return View();

            }
            else// extrato resumido por transação específica
            {

                var clienteContaTransLogTransViewModel2 = Mapper.Map<IEnumerable<LogTransacao>,
                   IEnumerable<ClienteContaTransLogTransViewModel>>(await _logTransacaoApp.ExtratoResumido(conta.idCliente, conta.IdConta,
                   transacao.IdTransacao, dataInicial, dataFinal));
                foreach (var item in clienteContaTransLogTransViewModel2)
                {
                    item.Transacao = transacao.Nome;
                    item.NConta = conta.NConta;
                }

                if (conta.idCliente != 0)
                {
                    TempData["TempData_clienteContaTransLogTransViewModel"] = clienteContaTransLogTransViewModel2;
                    return RedirectToAction("ListExtratoConta2");
                    // RedirectToAction("ListExtratoConta2", clienteContaTransLogTransViewModel2);
                }
                return View();
            }
        }

        public ActionResult ListExtratoConta2()
        {

            var clienteContaTransLogTransViewModel = TempData["TempData_clienteContaTransLogTransViewModel"] as IEnumerable<ClienteContaTransLogTransViewModel>;
            var conta = TempData["contaSelecinada"] as Conta; //conta cliente atual
            var cliente = TempData["clienteSelecionado"] as Cliente;
            string dadosConta = "Agência: " + conta.NAgencia + " - " + conta.ADigito + "    Conta: " + conta.NConta + " - " + conta.CDigito; //conta + Agencia do clliente

            ViewBag.nomeCliente = cliente.Nome;
            ViewBag.dadosConta = dadosConta;
            //int pagNumero = 1;

            TempData["TempData_clienteContaTransLogTransViewModel"] = clienteContaTransLogTransViewModel;
            TempData["contaSelecinada"] = conta;
            TempData["clienteSelecionado"] = cliente;
            //return new Rotativa.ViewAsPdf(View(clienteContaTransLogTransViewModel));
            return View(clienteContaTransLogTransViewModel);
        }
        public ActionResult ListExtratoConta2_Pdf()
        {
            var clienteContaTransLogTransViewModel = TempData["TempData_clienteContaTransLogTransViewModel"] as IEnumerable<ClienteContaTransLogTransViewModel>;
            var conta = TempData["contaSelecinada"] as Conta; //conta cliente atual
            var cliente = TempData["clienteSelecionado"] as Cliente;

            string dadosConta = "Agência: " + conta.NAgencia + " - " + conta.ADigito + "    Conta: " + conta.NConta + " - " + conta.CDigito; //conta + Agencia do clliente
            ViewBag.nomeCliente = cliente.Nome;
            ViewBag.dadosConta = dadosConta;


            return new Rotativa.ViewAsPdf("ListExtratoConta2", clienteContaTransLogTransViewModel);
            
        }
        // GET: Conta
        public async System.Threading.Tasks.Task<ActionResult> Index()
        //List<Conta> Contas = new List<Conta>();
        {
            var contaViewModel = Mapper.Map<IEnumerable<Conta>, IEnumerable<ContaViewModel>>(await _contaApp.ContasListar());
            List<ClienteContaViewModel> listaContaClienteViewModel = new List<ClienteContaViewModel>();

            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva conta)
            foreach (var clienteViewModel in contaViewModel)
            {
                Cliente cliente = new Cliente();

                cliente = await _clienteApp.BuscaClientePorId(Convert.ToInt32(clienteViewModel.idCliente)); //pega o proprietário de cada conta da Lista contaViewModel

                ClienteContaViewModel clienteContaViewModel = new ClienteContaViewModel
                {//criação de objeto view model contendo dados das contas com seus respectivos clientes 
                    idCliente = cliente.idCliente,
                    Cpf = cliente.Cpf,
                    Nome = cliente.Nome,
                    IdConta = clienteViewModel.IdConta,
                    NConta = clienteViewModel.NConta,
                    CDigito = clienteViewModel.CDigito,
                    NAgencia = clienteViewModel.NAgencia,
                    ADigito = clienteViewModel.ADigito,
                    Senha = clienteViewModel.Senha,
                    Saldo = clienteViewModel.Saldo

                };

                listaContaClienteViewModel.Add(clienteContaViewModel);

            }
            return View(listaContaClienteViewModel);
        }

        // GET: Conta/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            var contaViewModel = Mapper.Map<Conta, ContaViewModel>(await _contaApp.ContaListaCliente(id));//lista determinada conta pelo Id da conta


            //acrescentando os dados do cliente em uma ClienteViewModel (View model especial com propriedades do Cliente e sua respectiva conta)
            Cliente cliente = new Cliente();

            cliente = await _clienteApp.BuscaClientePorId(Convert.ToInt32(contaViewModel.idCliente)); //pega o proprietário de cada conta da Lista contaViewModel

            ClienteContaViewModel clienteContaViewModel = new ClienteContaViewModel
            {//criação de objeto view model contendo dados das contas com seus respectivos clientes 
                idCliente = cliente.idCliente,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                IdConta = contaViewModel.IdConta,
                NConta = contaViewModel.NConta,
                CDigito = contaViewModel.CDigito,
                NAgencia = contaViewModel.NAgencia,
                ADigito = contaViewModel.ADigito,
                Senha = contaViewModel.Senha,
                Saldo = contaViewModel.Saldo

            };


            return View(clienteContaViewModel);
        }


        // GET: Conta/CreateClienteConta
        public ActionResult CreateClienteConta()
        {
            return View();
        }
        // Post: Conta/CreateClienteConta
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateClienteConta(ClienteContaViewModel clienteContaViewModel)
        {
            var conta = Mapper.Map<ClienteContaViewModel, Conta>(clienteContaViewModel);
            Cliente cliente = new Cliente()
            {
                Nome = clienteContaViewModel.Nome,
                Cpf = clienteContaViewModel.Cpf,

            };

            if (cliente.IsValid())
            {
                _clienteApp.InserirCliente(cliente); //salva o cliente em banco
                var clienteTemp = new Cliente();
                clienteTemp = await _clienteApp.BuscaClientePorCPF(cliente.Cpf);
                cliente.idCliente = clienteTemp.idCliente; //atualiz o objeto cliente com o id salvo no banco                

                if (cliente.idCliente != 0)// se o cliente foi salvo no banco, salve a conta referente a ele
                {
                    conta.idCliente = cliente.idCliente;
                    conta.Saldo = 0;

                    _contaApp.InserirConta(conta);//salva a conta no banco

                    return RedirectToAction("Index"); ;
                }
                else// caso dê algum problema de salvamento do cliente no banco.
                {
                    this.AddNotification("Houve algum problema em registrar o cliente.", NotificationType.ERROR);
                    return View();
                }


            }
            else
            {
                this.AddNotification("CPF invalido.", NotificationType.ERROR);
                return View();
            }

        }

        // GET: Conta/Create
        public ActionResult Create()
        {
            //ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome");
            return View();
        }

        // POST: Conta/Create
        [HttpPost]
        public ActionResult Create(ClienteContaViewModel conta)
        {
            if (ModelState.IsValid)
            {
                var contaDomain = Mapper.Map<ClienteContaViewModel, Conta>(conta);
                _contaApp.InserirConta(contaDomain);

                return RedirectToAction("Index");
            }

            return View(conta);
        }

        // GET: Conta/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var contaDomain = await _contaApp.ContaListaCliente(id);
            var clienteContaViewModel = Mapper.Map<Conta, ClienteContaViewModel>(contaDomain);

            //ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome", clienteContaViewModel.idCliente);

            return View(clienteContaViewModel);
        }

        // POST: Conta/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteContaViewModel clienteConta)
        {
            if (ModelState.IsValid)
            {
                var contaDomain = Mapper.Map<ClienteContaViewModel, Conta>(clienteConta);
                _contaApp.AtualizarConta(contaDomain);

                return RedirectToAction("Index");
            }
            // ViewBag.idCliente = new SelectList(_clienteApp.BuscaTodosClientes(), "idCliente", "Nome", clienteConta.idCliente);
            return View(clienteConta);
        }

        // GET: Conta/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var contaDomain = await _contaApp.ContaListaCliente(id);
            var contaViewModel = Mapper.Map<Conta, ContaViewModel>(contaDomain);

            return View(contaViewModel);
        }

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteComfirmed(int id)
        {
            var conta = await _contaApp.ContaListaCliente(id);
            _contaApp.DeletarConta(conta);

            return RedirectToAction("Index");
        }
    }
}
