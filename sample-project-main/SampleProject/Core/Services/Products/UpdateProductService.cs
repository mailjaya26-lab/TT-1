using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{  [AutoRegister]
        public class UpdateProductService : IUpdateProductService
        {
            private readonly IProductRepository _productRepository;

            public UpdateProductService(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public IEnumerable<Product> Update(Product product, string name, string description, string category, decimal price, int quantity, DateTime createdAt, bool isActive)
                {
                    product.SetName(name);
                    product.SetDescription(description);
                    product.SetCategory(category);
                    product.SetPrice(price);
                    product.SetQuantity(quantity);
                    product.SetCreatedAt(createdAt);    
                    product.SetUpdatedAt(DateTime.Now);
                    product.SetIsActive(isActive);
                    return _productRepository.Update(product);
            }
        }
}
