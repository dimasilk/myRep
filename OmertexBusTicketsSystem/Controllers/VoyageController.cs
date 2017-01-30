using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.BL.SearchFilters;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace OmertexBusTicketsSystem.Controllers
{
    public class VoyageController : Controller
    {
        private readonly IVoyagesFactory _voyagesFactory;
        private readonly IVoyageService _voyageService;
        private readonly IBusStopService _busStopService;
        private readonly IBusStopsFactory _busStopsFactory;
        private readonly ITicketService _ticketService;
        public readonly ITicketsFactory _ticketsFactory;
        public VoyageController() { }

        public VoyageController(IVoyagesFactory voyagesFactory, IVoyageService voyageService, IBusStopService busStopService, IBusStopsFactory busStopsFactory, ITicketService ticketService, ITicketsFactory ticketsFactory)
        {
            _voyageService = voyageService;
            _voyagesFactory = voyagesFactory;
            _busStopService = busStopService;
            _busStopsFactory = busStopsFactory;
            _ticketService = ticketService;
            _ticketsFactory = ticketsFactory;
        }
        [Authorize]
        public ActionResult SearchVoyages()
        {
            List<BusStopModel> res = new List<BusStopModel>();
            var stops = _busStopService.GetAllBusStops();
            foreach (var element in stops)
            {
                res.Add(_busStopsFactory.Get(element));
            }
            SelectList slList = new SelectList(res, "Id", "Name");
            ViewBag.stops = slList;
            return View();
        }
        [Authorize]
        public ActionResult ApplyFilter(int? idArrivalStop, int? idDepartureStop, DateTime? from, DateTime? till)
        {
            var filter = new VoyagesSearchFilters()
            {
                FromDateTime = from,
                TillDateTime = till,
                ArrivalStopId = idArrivalStop,
                DepartureStopId = idDepartureStop
            };
            var res = _voyageService.GetVoyagesByFilter(filter);
            List<VoyageViewModel> models = new List<VoyageViewModel>();
            foreach (var element in res)
            {
                models.Add(_voyagesFactory.Get(element));
            }
            return PartialView(models);
        }
        // GET: Voyage
        public ActionResult Index()
        {
            return View();
        }

        // GET: Voyage/Details/5
        public ActionResult ReserveTickets(int id)
        {
            var res = _ticketService.GetFreeTicketsByVoyageId(id);
            List<TicketSimpleViewModel> models = new List<TicketSimpleViewModel>();
            foreach (var element in res)
            {
                models.Add(_ticketsFactory.GetSimple(element));
            }
            var voyage = _voyageService.GetVoyageById(id);
            var voyageView = _voyagesFactory.Get(voyage);
            ViewBag.voyage = voyageView;
            
            return View(models);
        }
        
        [HttpPost]
        public ActionResult ReserveTickets(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
