using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;
using OmertexBusTicketsSystem.BL.Mappings;

namespace OmertexBusTicketsSystem.BL.BusStopService
{
    public class BusStopService : IBusStopService
    {
        public IEnumerable<BusStopDto> GetAllBusStops()
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Busstop.Include(x => x.BusStopStatus).ToList();
                return temp?.Select(x => new BusStopDto(x)).ToList(); 
            }
        }

        public IEnumerable<BusStopDto> GetBusStopsByName(string name)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Busstop.Include(x=>x.SpecifiedVoyage).Include(x=>x.BusStopStatus).Where(x=> x.Name.Contains(name)).ToList();
                return temp?.Select(x => new BusStopDto(x)).ToList(); ;
            }
        }

        public BusStopDto GetBusStopById(int id)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Busstop.Find(id);

                if (temp != null) return new BusStopDto(temp);
            }
            return null;
        }

        public void DeleteBusStop(int busStopId)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Busstop temp = new Busstop();
                GetBusStopById(busStopId).CopyTo(temp);
                c.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                c.SaveChanges();
                return;
            }
        }

        public void UpdateBusStop(BusStopDto busStopModel)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Busstop dataModel = new Busstop();
                /*var temp = GetBusStopById(busStopModel.Id);
                temp.Description = busStopModel.Description;
                temp.Name = busStopModel.Name;
                temp.Status = busStopModel.Status;
                temp.Voyages = busStopModel.Voyages;
                temp.CopyTo(dataModel);*/
                busStopModel.CopyTo(dataModel);
                c.Entry(dataModel).State = System.Data.Entity.EntityState.Modified;
                c.SaveChanges();
                return;
            }
        }

        public void AddBusStop(BusStopDto busStopModel)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Busstop dataModel = new Busstop();
                busStopModel.CopyTo(dataModel);
                c.Busstop.Add(dataModel);
                c.SaveChanges();
                return;
            }
        }
    }
}
