using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IIdObjectFactory<Product> _productFactory;

        public CreateProductService(IIdObjectFactory<Product> productFactory, IProductRepository productRepository)
        {
          _productRepository = productRepository;
          _productFactory = productFactory;
        }
        public Product Create(Guid productId, string name, string description, string category, decimal price, int quantity, bool isActive)
        {
            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct != null)
            {
                productId = Guid.NewGuid();
            }
            Product product = _productFactory.Create(productId);
            product.SetName(name);
            product.SetDescription(description);
            product.SetCategory(category);
            product.SetPrice(price);
            product.SetQuantity(quantity);
            product.SetCreatedAt(DateTime.Now);
            product.SetUpdatedAt(DateTime.Now);
            product.SetIsActive(isActive);
            return _productRepository.Create(product);
        }

    }
}
