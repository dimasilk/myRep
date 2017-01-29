using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class TickedAdvancedViewModel
    {
        public int Id;
        public string Info;
        public int SeatNumber;
        //passengerViewModel
        public string Status;
        public string VoyageName;
        public DateTime ArrivaDateTime;
        public DateTime DepartureDateTime;
        public string BusStopArrivalName;
        public string BusStopDepartureName;
    }
}