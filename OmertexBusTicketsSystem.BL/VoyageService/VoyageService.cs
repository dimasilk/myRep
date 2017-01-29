using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.BL.SearchFilters;

namespace OmertexBusTicketsSystem.BL.VoyageService
{
    public class VoyageService : IVoyageService
    {
        public VoyageDto GetVoyageById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVoyage(int voyageId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVoyage(VoyageDto voyageModelDto)
        {
            throw new NotImplementedException();
        }

        public void AddVoyage(VoyageDto voyageModelDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoyageDto> GetVoyagesByFilter(VoyagesSearchFilters filter)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                int? arr = filter.ArrivalStopId;
                int? dep = filter.DepartureStopId;
                DateTime? dateFrom = filter.FromDateTime;
                DateTime? dateTill = filter.TillDateTime;


        var res = from x in c.SpecifiedVoyage.Include("BusstopArrival").Include("BusstopDeparture")
                    where (!dateFrom.HasValue || x.DatetimeDeparture > dateFrom.Value) &&
                          (!dateTill.HasValue || x.DatetimeArrival < dateTill.Value) &&
                          (!arr.HasValue || x.Id_BusStopArrival == arr.Value) &&
                          (!dep.HasValue || x.Id_BusStopDeparture == dep.Value)
                    select x;
                var models = new List<VoyageDto>();
                var mas = res.ToArray();
                foreach (var element in mas)
                {
                    models.Add(new VoyageDto(element));
                }

                return models; ;
            }
        }
    }
}
