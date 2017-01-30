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
        void DeleteOrder(int order);
        void UpdateOrder(OrderDto orderDto);
        void AddOrder(OrderDto orderDto);
        void MakeOrder(OrderDto orderDto);
        IEnumerable<OrderDto> GetOrdersByUserId(string userId);
    }
}
