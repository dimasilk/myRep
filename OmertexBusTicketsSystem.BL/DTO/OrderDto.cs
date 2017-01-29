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
            //UserId = order.Id_User;
        }
        public int Id;
        public VoyageDto Voyage;
        public StatusDto Status;
        public string UserId;
        public IEnumerable<TicketDto> Tickets;

        internal virtual void CopyTo(Order order)
        {
            order.Id = Id;
            //order.Id_User = UserId
            //tickets
            if(Status != null) Status.CopyTo(order.OrderStatus);
            if (Voyage != null) Voyage.CopyTo(order.SpecifiedVoyage);
        }
    }
}
