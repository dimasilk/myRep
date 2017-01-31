using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.ViewModels;
using OmertexBusTicketsSystem.ViewModelsFactories.Interdaces;

namespace OmertexBusTicketsSystem.ViewModelsFactories
{
    public class PassengersFactory : IPassengerFactory
    {
        public PassengerDto Get(PassengerViewModel passengerViewModel)
        {
            return new PassengerDto()
            {
                Birthdate = passengerViewModel.Birthdate,
               DocumentNumber = passengerViewModel.DocumentNumber,
               Firstname = passengerViewModel.Firstame,
               Surname = passengerViewModel.Surname,
            };
        }

        public PassengerViewModel Get(PassengerDto passengerDto)
        {
           return new PassengerViewModel()
           {
               Surname = passengerDto.Surname,
               DocumentNumber = passengerDto.DocumentNumber,
               Firstame = passengerDto.Firstname,
               Birthdate = passengerDto.Birthdate.Value,
               Id = passengerDto.Id
           };
        }
    }
}