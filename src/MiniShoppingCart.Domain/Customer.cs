namespace MiniShoppingCart.Domain
{
    using System;

    public class Customer
    {
        private ShoppingCart cart { get; set; }
        
        public Guid? Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public ShoppingCart Cart {  get
            {
                if (this.cart == null)
                {
                    this.cart = new ShoppingCart();
                }

                return this.Cart;
            }
        }

        private Customer()
        {
        }

        public Customer(
            Guid? id,
            string firstName,
            string lastName,
            string email,
            string address1,
            string address2,
            string city,
            string state,
            string country)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.Country = country;
        }

        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
