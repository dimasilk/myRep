using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    interface ITicketService
    {
        TicketDto GetTicketById(int id);
        void DeleteTicket(int ticketId);
        void UpdateTicket(TicketDto ticketDto);
        void AddTicket(TicketDto ticketDto);
    }
}
