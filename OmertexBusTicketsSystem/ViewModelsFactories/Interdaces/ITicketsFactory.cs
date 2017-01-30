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
        TickedAdvancedViewModel GetAdvanced(TicketDto dto);
        TicketsContainerViewModel GetModels(List<TicketSimpleViewModel> simpleViewModels);
        TicketDto GeTicketDto(TicketSimpleViewModel simpleViewModel);
    }
}
