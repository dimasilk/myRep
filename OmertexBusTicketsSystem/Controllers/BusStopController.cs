using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;


namespace OmertexBusTicketsSystem.Controllers
{
    public class BusStopController : Controller
    {
        private readonly IBusStopService _busStopService;
        private readonly IBusStopsFactory _busStopsFactory;

        public BusStopController(IBusStopsFactory busStopsFactory, IBusStopService busStopService)
        {
            _busStopService = busStopService;
            _busStopsFactory = busStopsFactory;
        }
        // GET: BusStop
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult FindBusStop(string name)
        {
            List<BusStopModel> res = new List<BusStopModel>();
            var stops = _busStopService.GetBusStopsByName(name);
            foreach (var element in stops)
            {
                res.Add(_busStopsFactory.Get(element));
            }
            return PartialView(res);
        }

  

 
       
    }
}
