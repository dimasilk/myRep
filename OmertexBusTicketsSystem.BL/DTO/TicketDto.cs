using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class TicketDto
    {
        public TicketDto() { }

        public TicketDto(Ticket ticket)
        {
            Id = ticket.Id;
            if (ticket.SpecifiedVoyage != null)
            {
                Voyage = new VoyageDto(ticket.SpecifiedVoyage);
            }
            
            if (ticket.Passenger != null)
            {
                Passenger = new PassengerDto(ticket.Passenger);
            }
            Info = ticket.info;
            
            if (ticket.TicketStatus != null)
            {
                Status = new StatusDto(ticket.TicketStatus);
            }
        }
        public int Id;
        public VoyageDto Voyage;
        public PassengerDto Passenger;
        public StatusDto Status;
        public string Info;
        public int SeatNumber;
        internal virtual void CopyTo(Ticket ticket)
        {
            ticket.Id = Id;
            if (Passenger != null) Passenger.CopyTo(ticket.Passenger);
            if (Status != null) Status.CopyTo(ticket.TicketStatus);
            if (Voyage != null) Voyage.CopyTo(ticket.SpecifiedVoyage);
            ticket.info = Info;
        }
    }
}
