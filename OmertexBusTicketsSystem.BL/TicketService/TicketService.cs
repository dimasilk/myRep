using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var temp = c.Ticket.Find(id);

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
            throw new NotImplementedException();
        }

        public void AddTicket(TicketDto ticketDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketDto> GetTicketsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketDto> GetFreeTicketsByVoyageId(int voyageId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Ticket.Where(x => x.Id_SpecifiedVoyage == voyageId).Where(x=>x.Id_Status == 1).ToList();
                return temp?.Select(x => new TicketDto(x)).ToList(); ;
            }
        }
    }
}
