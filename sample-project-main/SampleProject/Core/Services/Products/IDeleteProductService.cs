using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IDeleteProductService
    {
            void DeleteProduct(Product product);
            void DeleteAllProducts();
    }
}
