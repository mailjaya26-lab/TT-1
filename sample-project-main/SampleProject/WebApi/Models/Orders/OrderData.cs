using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderData:IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            UserId = order.UserId;
            TotalAmount = order.TotalAmount;
            ProductsOrdered = order.ProductsOrders;
            OrderDate = order.OrderDate;
            Status = order.Status;
        }
        public Guid UserId;
        public decimal TotalAmount;
        public Dictionary<Guid, int> ProductsOrdered;
        public DateTime OrderDate;
        public string Status;

    }
}