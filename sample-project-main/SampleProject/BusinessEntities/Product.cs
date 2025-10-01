using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Product:IdObject
    {
        private string _name;
        private string _description;
        private decimal _price;
        private int _quantity;
        private string _category;
        private DateTime _createdAt  = DateTime.UtcNow;
        private DateTime _updatedAt = DateTime.UtcNow;
        private bool _isActive;


        public string Name { 
            get => _name; 
            private set =>  _name = value; 
        }
        public string Description
        {
            get => _description;
            private set => _description = value;
        }
        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }
        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }
        public string Category
        {
            get => _category;
            private set => _category = value;
        }
        public DateTime CreatedAt
        {
            get => _createdAt;
            private set => _createdAt = value;
        }
        public DateTime UpdatedAt
        {
            get => _createdAt;
            private set => _createdAt = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }


        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public void SetDescription(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                _description  = desc;
            }
        }
        public void SetPrice(decimal price)
        {
            if (price > 0)
            {
                _price = price;
            }
        }
        public void SetQuantity(int qty)
        {
            if (qty >=0)
            {
                _quantity = qty;
            }
          
        }
        public void SetCategory(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                _category = category;
            }
        }
        public void SetCreatedAt(DateTime createdAt)
        {
            if (createdAt != default)
                _createdAt = createdAt;
        }
        public void SetUpdatedAt(DateTime updatedAt)
        {
            if (updatedAt != default)
                _updatedAt = updatedAt;
        }

        public void SetIsActive(bool isActive)
        {
            _isActive = isActive;
        }

    }
}
