namespace MiniShoppingCart.Domain
{
    using System;

    public class ShoppingCartItem
    {
        // Private ctor for EF persistence
        private ShoppingCartItem()
        {
        }

        public ShoppingCartItem(Product product, uint quantity) {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Guid? Id { get; private set; }
        public virtual Product Product { get; private set; }
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
