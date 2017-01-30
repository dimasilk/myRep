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
            
            if (ticket.Id_User != null)
            {
                UserId = ticket.Id_User;
            }

            if (ticket.TicketStatus != null)
            {
                Status = new StatusDto(ticket.TicketStatus);
            }

            if (ticket.Order != null)
            {
                Order = new OrderDto(ticket.Order);
            }
            Info = ticket.info;
            SeatNumber = ticket.SeatNumber.Value;
            
        }
        public int Id;
        public VoyageDto Voyage;
        public PassengerDto Passenger;
        public StatusDto Status;
        public OrderDto Order;
        public string Info;
        public int SeatNumber;
        public string UserId;

        internal virtual void CopyTo(Ticket ticket)
        {
            ticket.Id = Id;
            if (Passenger != null) ticket.Id_Passenger = Passenger.Id; //Passenger.CopyTo(ticket.Passenger);
            if (Status != null) ticket.Id_Status = Status.Id; //Status.CopyTo(ticket.TicketStatus);
            if (Voyage != null) ticket.Id_SpecifiedVoyage = Voyage.Id;
            if (Order != null) ticket.Id_Order = Order.Id;//Voyage.CopyTo(ticket.SpecifiedVoyage);
            ticket.info = Info;
            ticket.Id_User = UserId;
            ticket.SeatNumber = SeatNumber;
        }
    }
}
