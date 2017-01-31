using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class TickedAdvancedViewModel
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public int SeatNumber { get; set; }
        public bool Checked { get; set; }

        public string Status { get; set; }
        public string VoyageName { get; set; }
        public DateTime ArrivaDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string BusStopArrivalName { get; set; }
        public string BusStopDepartureName { get; set; }
        public int TicketCost { get; set; }
        public PassengerViewModel PassengerViewModel { get; set; }
    }
}