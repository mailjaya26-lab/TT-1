using BusinessEntities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProductById(Guid id);

        IEnumerable<Product> GetProductList();

    }
}
