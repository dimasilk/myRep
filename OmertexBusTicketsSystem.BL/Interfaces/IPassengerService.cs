using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    public interface IPassengerService
    {
        PassengerDto GetPassengerById(int id);
        void DeletePassenger(int passengerId);
        void UpdatePassenger(PassengerDto passengerModelDto);
        void AddPassenger(PassengerDto passengerModelDto);
        IEnumerable<PassengerDto> GetPassengersByUserId(string userId);
    }
}
