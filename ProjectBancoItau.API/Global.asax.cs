using ProjectBancoItau.API.App_Start;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectBancoItau.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SimpleInjectorContainer.Build()));
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
