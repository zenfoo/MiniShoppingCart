namespace MiniShoppingCart.Domain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public IList<ShoppingCartItem> Items { get; private set; }
        
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddItem(ShoppingCartItem item)
        {
            this.Items.Add(item);
        }

        public decimal GetTotalPrice()
        {
            return this.Items.Sum(i => i.GetTotalPrice());
        }
    }
}
