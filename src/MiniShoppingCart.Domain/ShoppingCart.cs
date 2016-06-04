namespace MiniShoppingCart.Domain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private ICollection<ShoppingCartItem> _items;

        public Guid? Id { get; private set; }
        public virtual ICollection<ShoppingCartItem> Items
        {
            get
            {
                return this._items ?? (this._items = new HashSet<ShoppingCartItem>());
            }
        }

        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        
        
        public ShoppingCart()
        {
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
