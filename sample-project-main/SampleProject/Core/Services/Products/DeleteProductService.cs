﻿using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteAllProducts()
        {
            _productRepository.DeleteAll();
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}
