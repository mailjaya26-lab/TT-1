using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : IProductRepository
    {
        private readonly ProductStore _products;

        public ProductRepository(ProductStore store)
        {
            _products = store;
        }
        public Product Create(Product product)
        {
            _products.Products.Add(product.Id, product);
            return product;
        }

        public void  Delete(Product product)
        {
            _products.Products.Remove(product.Id);
        }

        public void DeleteAll()
        {
           _products.Products.Clear();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products.Products.Values;
        }

        public Product GetById(Guid id)
        {
            _products.Products.TryGetValue(id, out var product);
            return product;
        }

        public IEnumerable<Product> Update(Product product)
        {
            _products.Products[product.Id] = product;
            return _products.Products.Values;

        }
    }
}
