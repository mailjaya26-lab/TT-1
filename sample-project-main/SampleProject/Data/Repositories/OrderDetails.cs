using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class OrderDetails
    {
        public Dictionary<Guid, Order> Orders { get; } = new Dictionary<Guid, Order>();
    }
}
