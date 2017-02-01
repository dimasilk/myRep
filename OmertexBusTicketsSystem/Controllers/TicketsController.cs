using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;
using WebGrease.Css;

namespace OmertexBusTicketsSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketsFactory _ticketsFactory;
        private readonly IPassengerFactory _passengerFactory;
        private readonly IPassengerService _passengerService;
        public TicketsController() { }

        public TicketsController(ITicketService ticketService, ITicketsFactory ticketsFactory, IPassengerFactory passengerFactory, IPassengerService passengerService)
        {
            _ticketsFactory = ticketsFactory;
            _ticketService = ticketService;
            _passengerFactory = passengerFactory;
            _passengerService = passengerService;
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
        public ActionResult MyTickets()
        {
            string userId = User.Identity.GetUserId();
            var reservedTicketsDto = _ticketService.GetReservedTicketsByUser(userId);
            var boughtTicketsDto = _ticketService.GetBoughtTicketsByUser(userId);
            List<TickedAdvancedViewModel> reservedTickets = new List<TickedAdvancedViewModel>();
            List<TickedAdvancedViewModel> boughtTickets = new List<TickedAdvancedViewModel>();

            foreach (var element in reservedTicketsDto)
            {
                reservedTickets.Add(_ticketsFactory.GetAdvanced(element));
            }
            foreach (var element in boughtTicketsDto)
            {
                boughtTickets.Add(_ticketsFactory.GetAdvanced(element));
                boughtTickets.Last().PassengerViewModel = _passengerFactory.Get(element.Passenger);
            }
            var boughtTicketsContainer = _ticketsFactory.GetModels(boughtTickets);
            var reservedTicketsContainer = _ticketsFactory.GetModels(reservedTickets);
            var model = _ticketsFactory.GetAllUsersTickets(reservedTicketsContainer, boughtTicketsContainer);

            return View(model);
        }
       

        public ActionResult TicketPassenger(UsersTicketsViewModel usersTickets)
        {
            List<TickedAdvancedViewModel> temp = new List<TickedAdvancedViewModel>();
            foreach (var element in usersTickets.ReservedTickets.TicketAdvanced)
            {
                if (element.Checked == true)
                {
                    //element.PassengerViewModel = new PassengerViewModel();
                    temp.Add(element);  
                }
            }
            usersTickets.ReservedTickets.TicketAdvanced = temp;
            usersTickets.BoughtTickets = null;

            return View(usersTickets);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        public ActionResult BuyTickets(UsersTicketsViewModel usersTicketsViewModel)
        {
            try
            {
                List<TicketDto> tickets = new List<TicketDto>();
                foreach (var element in usersTicketsViewModel.ReservedTickets.TicketAdvanced)
                {
                    tickets.Add(_ticketsFactory.GeTicketDto(element));
                    tickets.Last().Passenger = _passengerFactory.Get(element.PassengerViewModel);
                }
                _ticketService.BuyTickets(tickets);

                return RedirectToAction("MyTickets");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
