using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService:IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteAllOrders()
        {
            _orderRepository.DeleteAll();
        }

        public void DeleteOrder(Order order)
        {
            _orderRepository.Delete(order);
        }
    }
}
