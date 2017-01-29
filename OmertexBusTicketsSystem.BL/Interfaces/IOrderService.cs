using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int id);
        void DeleteOrder(int busStopId);
        void UpdateOrder(OrderDto busStopModel);
        void AddOrder(OrderDto busStopModel);
        void MakeOrder(IEnumerable<TicketDto> tickets);
        IEnumerable<OrderDto> GetOrdersByUserId(string userId);
    }
}
