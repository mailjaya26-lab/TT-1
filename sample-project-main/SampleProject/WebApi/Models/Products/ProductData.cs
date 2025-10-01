using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Xml.Linq;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
           Name = product.Name;
           Description = product.Description;
           Price = product.Price;
           Quantity = product.Quantity;
           Category = product.Category;
           CreatedAt = product.CreatedAt;
           UpdatedAt = product.UpdatedAt;
           IsActive = product.IsActive;
        }
        public string Name;
        public string Description;
        public decimal Price;
        public int Quantity;
        public string Category;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public bool IsActive;

    }
}