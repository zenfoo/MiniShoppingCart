namespace MiniShoppingCart.Domain.Tests
{
    using System;
    using MiniShoppingCart.Domain;
    using Xunit;

    public class ShoppingCartItemTests
    {
        [Fact]
        public void GetFullName_ReturnsFullName()
        {
            var product = new Product("Widget A", "71625", 2.5M);
            var cartItem = new ShoppingCartItem(product, 2);

            var price = cartItem.GetTotalPrice();

            Assert.Equal(5M, price);
        }
    }
}
