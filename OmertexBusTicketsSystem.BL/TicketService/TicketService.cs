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
                    .Include(x => x.SpecifiedVoyage)
                    .Include(x => x.SpecifiedVoyage.BusstopArrival)
                    .Include(x => x.SpecifiedVoyage.BusstopDeparture)
                    .Where(x => x.Id_User.Contains(userId)).Where(x => x.Id_Status == 2).ToList();
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
