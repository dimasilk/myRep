using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;

namespace OmertexBusTicketsSystem.BL.PassengerService
{
    public class PassengerService : IPassengerService
    {
        public PassengerDto GetPassengerById(int id)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Passenger
                    .Find(id);
                if (temp != null) return new PassengerDto(temp);
            }
            return null;
        }

        public void DeletePassenger(int passengerId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassenger(PassengerDto passengerModelDto)
        {
            throw new NotImplementedException();
        }

        public void AddPassenger(PassengerDto passengerModelDto)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Passenger dataModel = new Passenger();
                passengerModelDto.CopyTo(dataModel);
                c.Passenger.Add(dataModel);
                c.SaveChanges();
                return;
            }
        }

        public IEnumerable<PassengerDto> GetPassengersByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
