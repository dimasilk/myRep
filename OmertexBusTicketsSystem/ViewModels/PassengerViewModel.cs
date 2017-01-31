using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmertexBusTicketsSystem.ViewModels
{
    public class PassengerViewModel
    {
        public int Id { get; set; }
        public string Firstame { get; set; }
        public string Surname { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Birthdate { get; set; }
    }
}