namespace MiniShoppingCart.Domain
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(Product product, uint quantity) {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; private set; }
        public uint Quantity { get; private set; }

        public void UpdateQuantity(uint quantity)
        {
            this.Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return this.Product.UnitPrice * this.Quantity;
        }
    }
}
