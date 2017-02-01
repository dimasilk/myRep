using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.ViewModels;

namespace OmertexBusTicketsSystem.ViewModelsFactories.Interdaces
{
    public interface ITicketsFactory
    {
        TicketSimpleViewModel GetSimple(TicketDto dto);
        TickedAdvancedViewModel GetAdvanced(TicketDto dto, PassengerViewModel passengerViewModel = null);
        TicketsContainerViewModel GetModels(List<TicketSimpleViewModel> simpleViewModels);
        TicketsContainerViewModel GetModels(List<TickedAdvancedViewModel> simpleViewModels);
        TicketDto GeTicketDto(TicketSimpleViewModel simpleViewModel);
        TicketDto GeTicketDto(TickedAdvancedViewModel simpleViewModel);
        UsersTicketsViewModel GetAllUsersTickets(TicketsContainerViewModel reserved, TicketsContainerViewModel bought);
    }
}
