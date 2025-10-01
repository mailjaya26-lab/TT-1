using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name;
        public string Description;
        public decimal Price;
        public int Quantity;
        public string Category;
        public DateTime CreatedAt;
        public DateTime UpDatedAt;
        public bool IsActive;
    }
}