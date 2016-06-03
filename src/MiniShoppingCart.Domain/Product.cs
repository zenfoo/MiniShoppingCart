namespace MiniShoppingCart.Domain
{
    using System;

    public class Product
    {
        // Private ctor for EF persistence
        private Product()
        {
        }

        public Product(string name, decimal unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
        }

        public Guid? Id { get; private set; }
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}
