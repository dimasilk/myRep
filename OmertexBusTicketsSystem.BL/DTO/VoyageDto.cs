using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class VoyageDto
    {
        public VoyageDto() { }

        public VoyageDto(SpecifiedVoyage voyage)
        {
            Id = voyage.Id;
            if (voyage.BusstopArrival != null) BusStopArrival = new BusStopDto(voyage.BusstopArrival);
            if (voyage.BusstopDeparture != null) BusStopDeparture = new BusStopDto(voyage.BusstopDeparture);
            ArrivalDateTime = voyage.DatetimeArrival;
            DepartureDateTime = voyage.DatetimeDeparture;
            NumberOfSeats = voyage.NumberOfSeats;
            TicketCost = voyage.TicketCost;
            VoyageNumber = voyage.VoyageNumber;
            VoyageName = voyage.VoyageName;
            TravelTime = new TimeSpan((long)voyage.TravelTime * 10000000);
            if (voyage.Ticket != null)
            {
                Tickets = new List<TicketDto>();
                foreach (var element in voyage.Ticket)
                {
                    Tickets.Add(new TicketDto(element));
                }
            }


        }
        public int Id;
        public BusStopDto BusStopDeparture;
        public BusStopDto BusStopArrival;
        public DateTime? DepartureDateTime;
        public DateTime? ArrivalDateTime;
        public TimeSpan TravelTime;
        public string VoyageName;
        public int? VoyageNumber;
        public int? NumberOfSeats;
        public int? TicketCost;
        public List<TicketDto> Tickets;

        internal virtual void CopyTo(SpecifiedVoyage voyage)
        {
            voyage.Id = Id;
            voyage.DatetimeArrival = ArrivalDateTime;
            voyage.DatetimeDeparture = DepartureDateTime;
            voyage.NumberOfSeats = NumberOfSeats;
            voyage.TicketCost = TicketCost;
            voyage.VoyageNumber = VoyageNumber;
            voyage.VoyageName = VoyageName;
            //TravelTime = voyage.TravelTime;
            if (BusStopArrival != null) BusStopArrival.CopyTo(voyage.BusstopArrival);
            if (BusStopDeparture != null) BusStopDeparture.CopyTo(voyage.BusstopDeparture);

            if (Tickets != null)
            {
                foreach (var element in Tickets)
                {
                    var c = new Ticket();
                    element.CopyTo(c);
                    voyage.Ticket.Add(c);
                }
            }
        }
    }
}
