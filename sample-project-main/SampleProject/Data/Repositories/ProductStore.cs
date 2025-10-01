using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
        public class ProductStore
        {
            public Dictionary<Guid, Product> Products { get; } = new Dictionary<Guid, Product>();
        }
}
