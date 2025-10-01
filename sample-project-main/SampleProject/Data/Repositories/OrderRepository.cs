using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDetails _orderDetails;
        private readonly ProductStore _productStore;

        public OrderRepository(OrderDetails details, ProductStore productStore)
        {
            _orderDetails = details;
            _productStore = productStore;
        }
        public Order Create(Order order)
        {

            _orderDetails.Orders.Add(order.Id, order);
            foreach(var kvp in order.ProductsOrders)
            {
                int qty = _productStore.Products[kvp.Key].Quantity - kvp.Value;
                _productStore.Products[kvp.Key].SetQuantity(qty);  // deduct the available product qty.
            }
            return order;
        }

        public void Delete(Order order)
        {
            _orderDetails.Orders.Remove(order.Id);
            foreach (var kvp in order.ProductsOrders)
            {
                int qty = _productStore.Products[kvp.Key].Quantity + kvp.Value;
                _productStore.Products[kvp.Key].SetQuantity(qty);  // Add the available product qty.
            }
        }

        public void DeleteAll()
        {
            foreach (var kvpOrder in _orderDetails.Orders)
            {
                foreach (var kvpProducts in kvpOrder.Value.ProductsOrders)
                {
                    int qty = _productStore.Products[kvpProducts.Key].Quantity + kvpProducts.Value;
                    _productStore.Products[kvpProducts.Key].SetQuantity(qty);  // Add the available product qty.
                }
            }
            _orderDetails.Orders.Clear();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderDetails.Orders.Values;
        }

        public Order GetById(Guid id)
        {
            _orderDetails.Orders.TryGetValue(id, out var order);
            return order;
        }
    }
}
