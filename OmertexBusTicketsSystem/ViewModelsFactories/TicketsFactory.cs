using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace OmertexBusTicketsSystem.ViewModelsFactories
{
    public class TicketsFactory : ITicketsFactory
    {
        public TicketSimpleViewModel GetSimple(TicketDto dto)
        {
            return new TicketSimpleViewModel()
            {
                Id =  dto.Id,
                Info = dto.Info,
                SeatNumber = dto.SeatNumber,
                Checked = false
            };
        }

        public TickedAdvancedViewModel GetAdvanced(TicketDto dto)
        {
                return new TickedAdvancedViewModel()
                {
                    Id = dto.Id,
                    Info = dto.Info,
                    SeatNumber = dto.SeatNumber,
                    ArrivaDateTime = (DateTime)dto.Voyage.ArrivalDateTime,
                    DepartureDateTime = (DateTime)dto.Voyage.DepartureDateTime,
                    Status = dto.Status.Name,
                    VoyageName = dto.Voyage.VoyageName,
                    //BusStopArrivalName = dto.Voyage.
                    //BusStopDepartureName = 
                };
        }
    }
}