using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class TicketSimpleViewModel
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public int SeatNumber { get; set; }
        public bool Checked { get; set; }
    }
}