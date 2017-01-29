using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Mappings
{
    public static class BusStopsMapping
    {
        public static BusStopDto GetDTO(this Busstop xBusstop)
        {
            return new BusStopDto()
            {
                Id = xBusstop.Id,
                Description = xBusstop.Description,
                Name = xBusstop.Name,
                //Voyages = xBusstop.SpecifiedVoyage,
                //Status = xBusstop.BusStopStatus
            };
        }
        public static Busstop GetORM(this BusStopDto xBusstop)
        {
            return new Busstop()
            {
              // Id = xBusstop.Id,
               Description = xBusstop.Description,
               Name = xBusstop.Name
                //Voyages = xBusstop.SpecifiedVoyage,
                //Status = xBusstop.BusStopStatus
            };
        }
    }
}
