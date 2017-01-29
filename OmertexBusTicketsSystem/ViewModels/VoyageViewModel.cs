using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class VoyageViewModel
    {
        public int Id;
        public string VoyageName;
        public DateTime Departure;
        public DateTime Arrival;
        public string DepartureStop;
        public string ArrivalStop;
    }
}