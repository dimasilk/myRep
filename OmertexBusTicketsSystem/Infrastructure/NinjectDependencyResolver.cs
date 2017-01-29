using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Common.HttpClientWrapper.Interfaces;
using Common.HttpClientWrapper;
using OmertexBusTicketsSystem.BL.BusStopService;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.BL.VoyageService;
using OmertexBusTicketsSystem.ViewModelsFactories;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace WebApplication10.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;
        public NinjectDependencyResolver(IKernel k)
        {
            kernel = k;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRestClient>().To<RestClient>();
            kernel.Bind<IBusStopService>().To<BusStopService>();
            kernel.Bind<IVoyageService>().To<VoyageService>();
            kernel.Bind<IBusStopsFactory>().To<BusStopsFactory>();
            kernel.Bind<IVoyagesFactory>().To<VoyagesFactory>();
            kernel.Bind<ITicketsFactory>().To<TicketsFactory>();

        }
    }
}