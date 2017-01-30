using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class VoyageViewModel
    {
        public int Id { get; set; }
        public string VoyageName { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string DepartureStop { get; set; }
        public string ArrivalStop { get; set; }
    }
}