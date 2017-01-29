using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.Tests.Common.Infrastructure;

namespace OmertexBusTicketSystem.BL.Tests.BusStopsTest
{
    [TestClass]
    public class BusStopsTest : BaseTestClass
    {
        private readonly BusStopDto _busstop = new BusStopDto()
        {
            Id = 9999,
            Name = "Testing",
            Description = "123234rgdfhfghfgh"
        };

        [TestMethod]
        public void ShouldAddUpdateAndDeleteBusStop()
        {
            var context = Kernel.Get<IBusStopService>();
            context.AddBusStop(_busstop);
            var doc = context.GetBusStopsByName(_busstop.Name).First();
            Assert.IsNotNull(doc);
            doc.Description = "Updated";
            context.UpdateBusStop(doc);
            var updated = context.GetBusStopById(doc.Id);
            Assert.AreEqual(updated.Description, doc.Description);
            context.DeleteBusStop(doc.Id);
            doc = context.GetBusStopById(doc.Id);
            Assert.IsNull(doc);
        }

        [TestMethod]
        public void ShouldFindByName()
        {
            var context = Kernel.Get<IBusStopService>();
            var doc = context.GetBusStopsByName("12345");
            Assert.IsNotNull(doc);
        }
    }
}
