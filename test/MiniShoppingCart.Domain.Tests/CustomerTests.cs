namespace MiniShoppingCart.Domain.Tests
{
    using System;
    using MiniShoppingCart.Domain;
    using Xunit;
    public class CustomerTests
    {
        [Fact]
        public void GetFullName_ReturnsFullName()
        {
            var customer = new Customer("Peter", "Doobes", "peter@doobes.com", "123 Test Street", "5D", "New York", "NY", "US");

            var name = customer.GetFullName();

            Assert.Equal("Peter Doobes", name);
        }
    }
}
