using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class StatusDto
    {
        public StatusDto() { }

        public StatusDto(OrderStatus orderStatus)
        {
            Id = orderStatus.Id;
            Name = orderStatus.Name;
        }
        public StatusDto(TicketStatus ticketStatus)
        {
            Id = ticketStatus.Id;
            Name = ticketStatus.Name;
        }
        public StatusDto(BusStopStatus busStopStatus)
        {
            Id = busStopStatus.Id;
            Name = busStopStatus.Name;
        }
        public int Id;
        public string Name;

        internal virtual void CopyTo(OrderStatus orderStatus)
        {
            orderStatus.Id = Id;
            orderStatus.Name = Name;
        }
        internal virtual void CopyTo(TicketStatus ticketStatus)
        {
            ticketStatus.Id = Id;
            ticketStatus.Name = Name;
        }
        internal virtual void CopyTo(BusStopStatus busStopStatus)
        {
            busStopStatus.Id = Id;
            busStopStatus.Name = Name;
        }
    }
}
