using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class UsersTicketsViewModel
    {
        public TicketsContainerViewModel ReservedTickets { get; set; }
        public TicketsContainerViewModel BoughtTickets { get; set; }
    }
}