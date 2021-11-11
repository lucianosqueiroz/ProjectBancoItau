using Microsoft.ApplicationInsights.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjectBancoItau.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjectBancoItau.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectBancoItau.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Application;
    using Application.Interface;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Interfaces.Repositories;
    using Infra.Data.Repositorios;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            try
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                bootstrapper.Initialize(CreateKernel);
            }
            catch (Exception e)
            { 
                
            }
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IContaAppService>().To<ContaAppService>();
            kernel.Bind<ITransacaoAppService>().To<TransacaoAppService>();
            kernel.Bind<ILogTransacaoAppService>().To<LogTransacaoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IContaService>().To<ContaService>();
            kernel.Bind<ITransacaoService>().To<TransacaoService>();
            kernel.Bind<ILogTransacaoService>().To<LogTransacaoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RespositoryBase<>));
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IContaRepository>().To<ContaRepository>();
            kernel.Bind<ITransacaoRepository>().To<TransacaoRepository>();
            kernel.Bind<ILogTransacaoRepository>().To<LogTransacaoRepository>();
        }
    }
}