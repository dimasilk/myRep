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

        public TicketsContainerViewModel GetModels(List<TicketSimpleViewModel> simpleViewModels)
        {
            return new TicketsContainerViewModel() {TicketSimple = simpleViewModels};
        }
        public TicketsContainerViewModel GetModels(List<TickedAdvancedViewModel> advancedViewModels)
        {
            return new TicketsContainerViewModel() { TicketAdvanced = advancedViewModels };
        }

        public TicketDto GeTicketDto(TicketSimpleViewModel simpleViewModel)
        {
            return new TicketDto()
            {
                Id = simpleViewModel.Id
            };
        }

        public UsersTicketsViewModel GetAllUsersTickets(TicketsContainerViewModel reserved, TicketsContainerViewModel bought)
        {
            return new UsersTicketsViewModel()
            {
                BoughtTickets = bought,
                ReservedTickets = reserved
            };
        }

        public TicketDto GeTicketDto(TickedAdvancedViewModel advancedViewModel, PassengerDto passengerDto)
        {
            return new TicketDto()
            {
                Id = advancedViewModel.Id,
                Passenger = passengerDto
            };
        }

        public TickedAdvancedViewModel GetAdvanced(TicketDto dto, PassengerViewModel passengerViewModel = null)
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
                    BusStopArrivalName = dto.Voyage.BusStopArrival.Name,
                    BusStopDepartureName = dto.Voyage.BusStopArrival.Name,
                    TicketCost = dto.Voyage.TicketCost.Value,
                    PassengerViewModel = passengerViewModel
                };
        }
    }
}