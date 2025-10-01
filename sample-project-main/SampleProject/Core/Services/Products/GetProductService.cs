﻿using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProductById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductList()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
