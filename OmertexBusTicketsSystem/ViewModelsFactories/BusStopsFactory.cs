using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace OmertexBusTicketsSystem.ViewModelsFactories
{
    public class BusStopsFactory : IBusStopsFactory
    {
        public BusStopModel Get(BusStopDto dto)
        {
            return new BusStopModel()
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Status = dto.Status.Name
            };
        }

        public BusStopDto Get(BusStopModel model)
        {
            return new BusStopDto()
            {
                Name = model.Name,
                Id = model.Id,
                Description = model.Description
            };
        }
    }
}