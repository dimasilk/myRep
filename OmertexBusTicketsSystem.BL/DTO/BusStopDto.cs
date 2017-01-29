using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;
using LinqKit;

namespace OmertexBusTicketsSystem.BL.DTO
{

    public class BusStopDto
    {
        public BusStopDto(Busstop busstop)
        {
            Id = busstop.Id;
            Name = busstop.Name;
            Description = busstop.Description;
            if (busstop.BusStopStatus != null)
            {
                Status = new StatusDto(busstop.BusStopStatus);
            }
        }

        public BusStopDto() {}

        public int Id;
        public string Name;
        public string Description;
        public StatusDto Status;
        public IEnumerable<VoyageDto> Voyages;

       
        internal virtual void CopyTo(Busstop busstop)
        {
            busstop.Id = this.Id;
            busstop.Description = Description;
            busstop.Name = Name;
            if (busstop.BusStopStatus != null)
            {
                Status.CopyTo(busstop.BusStopStatus);
                busstop.Id_BusStopStatus = Status.Id;
            }
            if (Voyages != null)
            {
                foreach (var element in Voyages)
                {
                    var c = new SpecifiedVoyage();
                    element.CopyTo(c);
                    busstop.SpecifiedVoyage.Add(c);    
                }
                
            }
        }
    }
}
