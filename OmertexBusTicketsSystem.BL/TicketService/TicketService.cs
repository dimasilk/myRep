using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;

namespace OmertexBusTicketsSystem.BL.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly IPassengerService _passengerService;
        public TicketService() { }

        public TicketService(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        public TicketDto GetTicketById(int id)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket.Include("TicketStatus")
                    .SingleOrDefault(x => x.Id == id); 
                if (temp != null) return new TicketDto(temp);
            }
            return null;
        }

        public void DeleteTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(TicketDto ticketDto)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket.Include("TicketStatus")
                    .Include("Order")
                    .Include("Passenger")
                    .Include("SpecifiedVoyage")
                  .SingleOrDefault(x => x.Id == ticketDto.Id);
               
                ticketDto.CopyTo(temp);
                c.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                c.SaveChanges();
                return;
            }
        }

        public void AddTicket(TicketDto ticketDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketDto> GetReservedTicketsByUser(string userId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket
                    .Include(x => x.SpecifiedVoyage.BusstopArrival)
                    .Include(x => x.SpecifiedVoyage.BusstopDeparture)
                    .Where(x => x.Id_User.Contains(userId)).Where(x => x.Id_Status == 2).ToList();
                foreach (var element in temp)
                {
                    element.SpecifiedVoyage.Ticket = null;
                }
                return temp?.Select(x => new TicketDto(x)).ToList();
            }
        }


        public IEnumerable<TicketDto> GetBoughtTicketsByUser(string userId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket
                    .Include(x => x.Passenger)
                    .Include(x => x.SpecifiedVoyage)
                    .Include(x => x.SpecifiedVoyage.BusstopArrival)
                    .Include(x => x.SpecifiedVoyage.BusstopDeparture)
                    .Where(x => x.Id_User.Contains(userId)).Where(x => x.Id_Status == 3).ToList();
                foreach (var element in temp)
                {
                    element.SpecifiedVoyage.Ticket = null;
                }
                return temp?.Select(x => new TicketDto(x)).ToList();
            }
        }

        public IEnumerable<TicketDto> GetFreeTicketsByVoyageId(int voyageId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket.Where(x => x.Id_SpecifiedVoyage == voyageId).Where(x=>x.Id_Status == 1).ToList();
                return temp?.Select(x => new TicketDto(x)).ToList(); 
            }
        }

        public void ReserveTickets(List<TicketDto> list, string userId)
        {
            int VoyageId = 0;
            foreach (var element in list)
            {
                var ticket = GetTicketById(element.Id);
               // if(VoyageId == 0) VoyageId = ticket.
                ticket.Status.Id = 2;
                ticket.Status.Name = "Reserved";
                ticket.UserId = userId;
                UpdateTicket(ticket);
            }
        }

        public void BuyTickets(List<TicketDto> list)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                foreach (var element in list)
                {
                    Passenger dataModel = new Passenger();
                    element.Passenger.CopyTo(dataModel);
                    c.Passenger.Add(dataModel);
                    c.SaveChanges();

                    var ticket = GetTicketById(element.Id);
                    ticket.Status.Id = 3;
                    ticket.Passenger = new PassengerDto(dataModel);
                    ticket.Passenger.IdUserCreated = ticket.UserId;
                    UpdateTicket(ticket);
                    ;
                    // _passengerService.AddPassenger(ticket.Passenger);
                }
            }
        }

        public int GetVoyageIdByTicketId(int ticketId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket.SingleOrDefault(x => x.Id == ticketId);
                if (temp != null) return (int)temp.Id_SpecifiedVoyage;
            }
            return 0;
        }
    }
}
