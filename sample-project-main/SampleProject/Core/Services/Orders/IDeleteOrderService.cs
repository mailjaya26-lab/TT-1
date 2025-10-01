using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IDeleteOrderService
    {
        void DeleteOrder(Order order);
        void DeleteAllOrders();
    }
}
