namespace MiniShoppingCart.Domain
{
    public class Product
    {
        public Product(string name, string productId, decimal unitPrice)
        {
            this.Name = name;
            this.ProductId = productId;
            this.UnitPrice = unitPrice;
        }

        public string Name { get; private set; }
        public string ProductId { get; private set;  }
        public decimal UnitPrice { get; private set; }
    }
}
