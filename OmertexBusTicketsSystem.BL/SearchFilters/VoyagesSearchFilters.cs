using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.BL.SearchFilters
{
    public class VoyagesSearchFilters
    {
       // [DateType(DateType.Date)]
        public DateTime? FromDateTime { get; set; }
        public DateTime? TillDateTime { get; set; }
        public int? DepartureStopId { get; set; }
        public int? ArrivalStopId { get; set; }
    }
}