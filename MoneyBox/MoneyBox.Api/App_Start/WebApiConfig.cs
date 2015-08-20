using Microsoft.Practices.Unity;
using MoneyBox.Core;
using MoneyBox.Data.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MoneyBox.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            //container.RegisterType<ITransactionRepository, TransactionRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ITransactionRepository, TransactionRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new TransactionRepository()));

            config.DependencyResolver = new UnityResolver(container);

            
        }
    }
}
