using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        IEnumerable<Product> Update(Product product, string name, string description, string category, decimal price, int quantity, DateTime createdAt, bool isActive);
    }
}
