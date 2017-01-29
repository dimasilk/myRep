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
            Voyage = new VoyageDto(ticket.SpecifiedVoyage);
            Passenger= new PassengerDto(ticket.Passenger);
            Info = ticket.info;
            Status = new StatusDto(ticket.TicketStatus);
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
            Passenger.CopyTo(ticket.Passenger);
            Status.CopyTo(ticket.TicketStatus);
            Voyage.CopyTo(ticket.SpecifiedVoyage);
            ticket.info = Info;
        }
    }
}
