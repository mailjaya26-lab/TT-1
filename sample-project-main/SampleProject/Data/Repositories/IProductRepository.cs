using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        IEnumerable<Product> GetAllProducts(); 

        Product GetById(Guid id);
        IEnumerable<Product> Update(Product product);
        void Delete(Product product);

        void DeleteAll();
    }
}
