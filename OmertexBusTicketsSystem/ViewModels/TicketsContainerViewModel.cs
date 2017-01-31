using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class TicketsContainerViewModel
    {
        public List<TicketSimpleViewModel> TicketSimple { get; set; }
        public List<TickedAdvancedViewModel> TicketAdvanced { get; set; }
    }
}