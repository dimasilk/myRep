using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DataModel;
using OmertexBusTicketsSystem.BL.DTO;
using OmertexBusTicketsSystem.BL.Interfaces;

namespace OmertexBusTicketsSystem.BL.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly ITicketService _ticketService;
        public OrderService() { }

        public OrderService(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public OrderDto GetOrderById(int id)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                var temp = c.Order
                    .SingleOrDefault(x => x.Id == id);
                if (temp != null) return new OrderDto(temp);
            }
            return null;
        
    }

        public void DeleteOrder(int order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(OrderDto orderDto)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Order dataModel = new Order();
                orderDto.CopyTo(dataModel);
                c.Order.Add(dataModel);
                c.SaveChanges();
                return;
            }
        }

        public void MakeOrder(OrderDto orderDto)
        {
            using (var c = new OmertexTicketsDBEntities())
            {
                Order dataModel = new Order();
                dataModel.Id_Status = 2;
                dataModel.Id_SpecifiedVoyage = _ticketService.GetVoyageIdByTicketId(orderDto.Tickets.First().Id);
                orderDto.CopyTo(dataModel);
                c.Order.Add(dataModel);
                c.SaveChanges();

                foreach (var element in orderDto.Tickets)
                {
                    element.UserId = orderDto.UserId;
                }
                _ticketService.ReserveTickets(orderDto.Tickets, orderDto.UserId);

                return;
            }
        }

        public IEnumerable<OrderDto> GetOrdersByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
