﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid orderId, Guid userId, Dictionary<Guid, int> productsOrdered);
    }
}
