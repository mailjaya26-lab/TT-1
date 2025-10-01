using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrderById(Guid id);

        IEnumerable<Order> GetOrderList();
    }
}
