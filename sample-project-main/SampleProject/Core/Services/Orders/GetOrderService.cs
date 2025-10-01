using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService:IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetOrderById(Guid id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrderList()
        {
            return _orderRepository.GetAllOrders();
        }
    }
}
