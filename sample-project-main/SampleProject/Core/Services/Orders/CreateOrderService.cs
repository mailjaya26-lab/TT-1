using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public  class CreateOrderService: ICreateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IProductRepository _productRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;
            _productRepository = productRepository;
        }
        public Order Create(Guid orderId, Guid userId, Dictionary<Guid, int> productsOrdered)
        {
            decimal totalCalculatedAmount = 0;
            foreach (var kvp in productsOrdered)
            {
                var product = _productRepository.GetById(kvp.Key);
                if (product != null)
                {
                    totalCalculatedAmount += kvp.Value * product.Price;
                }
            }
            if (totalCalculatedAmount > 0)
            {
                var existingOrder = _orderRepository.GetById(orderId);
                if (existingOrder != null)
                {
                    orderId = Guid.NewGuid();
                }
                Order order = _orderFactory.Create(orderId);
                order.SetUserId(userId);
                order.SetOrderDate(DateTime.Now);
                order.SetStatus("Order Placed");
                order.SetProductOrdered(productsOrdered);
                order.SetTotalAmount(totalCalculatedAmount);

                return _orderRepository.Create(order);
            } else
            {
                throw new ArgumentNullException("Order total amount is in valid");
            }
        }

    }
}
