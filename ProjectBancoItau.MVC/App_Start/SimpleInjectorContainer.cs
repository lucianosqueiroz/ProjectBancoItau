using ProjectBancoItau.Application;
using ProjectBancoItau.Application.Interface;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using ProjectBancoItau.Domain.Interfaces.Services;
using ProjectBancoItau.Domain.Services;
using ProjectBancoItau.Infra.Data.Repositorios;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static Container Build()
        {
            var container = new Container();


            //registrando implementações
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IClienteAppService, ClienteAppService>();
            container.Register<IContaAppService, ContaAppService>();
            container.Register<ITransacaoAppService, TransacaoAppService>();
            container.Register<ILogTransacaoAppService, LogTransacaoAppService>();

            container.Register<IUsuarioService, UsuarioService>();
            container.Register<IClienteService, ClienteService>();
            container.Register<IContaService, ContaService>();
            container.Register<ITransacaoService, TransacaoService>();
            container.Register<ILogTransacaoService, LogTransacaoService>();

            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IContaRepository, ContaRepository>();
            container.Register<ITransacaoRepository, TransacaoRepository>();
            container.Register<ILogTransacaoRepository, LogTransacaoRepository>();


            container.Verify();
            return container;
        }
    }
}