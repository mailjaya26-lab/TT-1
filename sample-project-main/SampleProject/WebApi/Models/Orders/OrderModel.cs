using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId;
        public decimal TotalAmount;
        public Dictionary<Guid, int> ProductsOrdered;
        public DateTime OrderDate;
        public string Status;

    }
}