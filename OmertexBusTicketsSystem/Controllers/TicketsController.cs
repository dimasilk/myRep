using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;
using WebGrease.Css;

namespace OmertexBusTicketsSystem.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketService _ticketService;
        private ITicketsFactory _ticketsFactory;
        private IPassengerFactory _passengerFactory;
        public TicketsController() { }

        public TicketsController(ITicketService ticketService, ITicketsFactory ticketsFactory, IPassengerFactory passengerFactory)
        {
            _ticketsFactory = ticketsFactory;
            _ticketService = ticketService;
            _passengerFactory = passengerFactory;
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Edit/5
        public ActionResult MyTickets(int id)
        {
            string userId = User.Identity.GetUserId();
            var reservedTicketsDto = _ticketService.GetReservedTicketsByUser(userId);
            var boughtTicketsDto = _ticketService.GetBoughtTicketsByUser(userId);
            List<TickedAdvancedViewModel> reservedTickets = new List<TickedAdvancedViewModel>();
            List<TickedAdvancedViewModel> boughtTickets = new List<TickedAdvancedViewModel>();

            foreach (var element in boughtTicketsDto)
            {
                reservedTickets.Add(_ticketsFactory.GetAdvanced(element));
            }
            foreach (var element in reservedTicketsDto)
            {
                boughtTickets.Add(_ticketsFactory.GetAdvanced(element));
            }
            var boughtTicketsContainer = _ticketsFactory.GetModels(boughtTickets);
            var reservedTicketsContainer = _ticketsFactory.GetModels(reservedTickets);
            var model = _ticketsFactory.GetAllUsersTickets(reservedTicketsContainer, boughtTicketsContainer);

            return View(model);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        public ActionResult MyTickets(TicketsContainerViewModel containerViewModel, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("MyTickets");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
