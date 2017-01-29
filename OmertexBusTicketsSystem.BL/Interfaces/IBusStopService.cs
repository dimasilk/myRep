using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    public interface IBusStopService
    {
        IEnumerable<BusStopDto> GetAllBusStops();
        IEnumerable<BusStopDto> GetBusStopsByName(string name);
        BusStopDto GetBusStopById(int id);
        void DeleteBusStop(int busStopId);
        void UpdateBusStop(BusStopDto busStopModel);
        void AddBusStop(BusStopDto busStopModel);
    }
}
