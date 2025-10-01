using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public  interface IOrderRepository
    {
        Order Create(Order order);
        IEnumerable<Order> GetAllOrders();

        Order GetById(Guid id);
        // IEnumerable<Order> Update(Product product);  // No Update Order. User needs to cancel order and create new order.
        void Delete(Order order);

        void DeleteAll();
    }
}
