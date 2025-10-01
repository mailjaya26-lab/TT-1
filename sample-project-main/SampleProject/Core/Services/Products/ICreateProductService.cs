using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid productId, string name, string description,string category, decimal price, int quantity, bool isActive);

    }
}
