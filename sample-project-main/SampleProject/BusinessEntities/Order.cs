using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private Guid _userId;
        private decimal _totalAmount;
        private Dictionary<Guid, int> _productsOrdered;
        private DateTime _orderDate = DateTime.UtcNow;
        private string _status;


        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }
        public decimal TotalAmount
        {
            get => _totalAmount;
            private set => _totalAmount = value;
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }
        public string Status
        {
            get => _status;
            private set => _status = value;
        }

        public Dictionary<Guid,int> ProductsOrders
        {
            get => _productsOrdered;
            private set => _productsOrdered = value;
        }

        public void SetUserId(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("User Id was not provided.");
            }
            _userId = userId;
        }

        public void SetStatus(string status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                _status = status;
            }
        }
        public void SetTotalAmount(decimal price)
        {
            if (price > 0)
            {
                _totalAmount = price;
            }
        }

        public void SetOrderDate(DateTime orderDate)
        {
            if (orderDate != default)
                _orderDate = orderDate;
        }
        
        public void SetProductOrdered(Dictionary<Guid,int> productsOrdered)
        {
            _productsOrdered = productsOrdered;
        }

    }
}
