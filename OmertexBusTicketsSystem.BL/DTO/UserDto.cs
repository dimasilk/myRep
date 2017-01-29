using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class UserDto
    {
        public string Id;
        public string Firstname;
        public string Surname;
        public string Username;
        public string Mail;
        public DateTime Birthdate;

        public IEnumerable<PassengerDto> Passengers;
        public IEnumerable<TicketDto> Tickets;
        public IEnumerable<OrderDto> Orders;

    }
}
