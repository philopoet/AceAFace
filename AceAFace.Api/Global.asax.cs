using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AceAFace.Api.Infrastructure;
using AceAFace.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AceAFace.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
          //  RouteConfig.RegisterRoutes(RouteTable.Routes);
          //  BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer();
            var aceAFaceRegistrar = new Registrar();
            aceAFaceRegistrar.Setup(container);

            var controllerActivator = new CastleControllerActivator(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerActivator), controllerActivator);
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<System.Web.Http.Controllers.IHttpController>(). //Web API
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());
        }
    }
}
