using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class OrderDto
    {
        public OrderDto() { }

        public OrderDto(Order order)
        {
            Id = order.Id;
            Voyage = new VoyageDto(order.SpecifiedVoyage);
            Status = new StatusDto(order.OrderStatus);
            
            //Tickets = order.
            UserId = order.Id_User;
        }
        public int Id;
        public VoyageDto Voyage;
        public StatusDto Status;
        public string UserId;
        public List<TicketDto> Tickets;

        internal virtual void CopyTo(Order order)
        {
            order.Id = Id;
            order.Id_User = UserId;
            //tickets
            if (Status != null) order.Id_Status = Status.Id; //Status.CopyTo(order.OrderStatus);
            if (Voyage != null) order.Id_SpecifiedVoyage = Voyage.Id; //Voyage.CopyTo(order.SpecifiedVoyage);
        }
    }
}
