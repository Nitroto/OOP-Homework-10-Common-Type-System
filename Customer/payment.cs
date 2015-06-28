using System;

namespace Customer
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("productName", "Product name cannot be empty");
                }
                this.productName = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.Price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative");
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            string output = string.Format("{0} - {1:C}", this.productName, this.price);
            return output;
        }
    }
}
