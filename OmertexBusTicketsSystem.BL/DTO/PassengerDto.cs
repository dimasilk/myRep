using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;

namespace OmertexBusTicketsSystem.BL.DTO
{
    public class PassengerDto
    {
        public PassengerDto() { }

        public PassengerDto(Passenger passenger)
        {
            Id = passenger.Id;
            Surname = passenger.Surname;
            Firstname = passenger.Firstname;
            Birthdate = passenger.Birthdate;
            DocumentNumber = passenger.DocumentNumber;
            SeatNumber = passenger.SeatNumber;
            //IdUserCreated = passenger.Id_UserCreated;

        }

        int Id;
        public string Firstname;
        public string Surname;
        public DateTime? Birthdate;
        public string DocumentNumber;
        public int? SeatNumber;
        public string IdUserCreated;

        internal virtual void CopyTo(Passenger passenger)
        {
            passenger.Firstname = Firstname;
            passenger.Surname = Surname;
            passenger.Birthdate = Birthdate;
            passenger.DocumentNumber = DocumentNumber;
            passenger.SeatNumber = SeatNumber;
            //passenger.Id_UserCreated = IdUserCreated;
            passenger.Id = Id;
        }
    }
}
