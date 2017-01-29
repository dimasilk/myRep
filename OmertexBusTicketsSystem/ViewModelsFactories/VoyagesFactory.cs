using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace OmertexBusTicketsSystem.ViewModelsFactories
{
    public class VoyagesFactory : IVoyagesFactory
    {
        public VoyageViewModel Get(VoyageDto voyageDto)
        {
            return new VoyageViewModel()
            {
                Id = voyageDto.Id,
                Arrival = voyageDto.ArrivalDateTime.Value,
                Departure = voyageDto.DepartureDateTime.Value,
                VoyageName = voyageDto.VoyageName,
                ArrivalStop = voyageDto.BusStopArrival.Name,
                DepartureStop = voyageDto.BusStopDeparture.Name
            };
        }
    }
}