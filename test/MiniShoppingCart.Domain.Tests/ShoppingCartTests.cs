namespace MiniShoppingCart.Domain.Tests
{
    using System;
    using MiniShoppingCart.Domain;
    using Xunit;

    public class ShoppingCartTests
    {
        [Fact]
        public void GetCartTotal_NoItems_ReturnsZero()
        {
            var cart = new ShoppingCart();

            var totalPrice = cart.GetTotalPrice();

            Assert.Equal(0M, totalPrice);
        }

        [Fact]
        public void GetCartTotal_OneItem_ReturnsCorrectSum()
        {
            var cart = new ShoppingCart();
            var cartItem = new ShoppingCartItem(new Product("Widget A", 12.34M), 1);
            cart.AddItem(cartItem);

            var totalPrice = cart.GetTotalPrice();

            Assert.Equal(12.34M, totalPrice);
        }

        [Fact]
        public void GetCartTotal_TwoItems_ReturnsCorrectSum()
        {
            var cart = new ShoppingCart();
            cart.AddItem(new ShoppingCartItem(new Product("Widget A", 12.34M), 2));

            var totalPrice = cart.GetTotalPrice();

            Assert.Equal(12.34M * 2, totalPrice);
        }

        [Fact]
        public void GetCartTotal_TwoProducts_ReturnsCorrectSum()
        {
            var cart = new ShoppingCart();
            cart.AddItem(new ShoppingCartItem(new Product("Widget A", 12.34M), 1));
            cart.AddItem(new ShoppingCartItem(new Product("Widget B", 10.44M), 1));

            var totalPrice = cart.GetTotalPrice();

            Assert.Equal(12.34M + 10.44M, totalPrice);
        }
    }
}
