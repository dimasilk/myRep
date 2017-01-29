using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.SearchFilters;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    public interface IVoyageService
    {
        VoyageDto GetVoyageById(int id);
        void DeleteVoyage(int voyageId);
        void UpdateVoyage(VoyageDto voyageModelDto);
        void AddVoyage(VoyageDto voyageModelDto);

        IEnumerable<VoyageDto> GetVoyagesByFilter(VoyagesSearchFilters filter);
    }
}
