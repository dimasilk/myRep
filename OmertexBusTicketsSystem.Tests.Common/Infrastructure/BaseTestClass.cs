using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.HttpClientWrapper;
using Common.HttpClientWrapper.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OmertexBusTicketsSystem.BL.BusStopService;
using OmertexBusTicketsSystem.BL.Interfaces;

namespace OmertexBusTicketsSystem.Tests.Common.Infrastructure
{
    [TestClass]
    public abstract class BaseTestClass
    {
        protected IKernel Kernel;

        [TestInitialize]
        public virtual void InitContainer()
        {
            this.Kernel = new StandardKernel();
            AddBindings();
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            if (this.Kernel != null)
                this.Kernel.Dispose();
        }

        private void AddBindings()
        {
            this.Kernel.Bind<IRestClient>().To<RestClient>();
            this.Kernel.Bind<IBusStopService>().To<BusStopService>();
        }
    }
}
