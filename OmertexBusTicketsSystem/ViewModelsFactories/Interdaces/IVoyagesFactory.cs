using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.ViewModels;

namespace OmertexBusTicketsSystem.ViewModelsFactories.Interdaces
{
    public interface IVoyagesFactory
    {
        VoyageViewModel Get(VoyageDto voyageDto);
    }
}
