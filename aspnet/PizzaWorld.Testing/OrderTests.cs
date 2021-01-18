using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class OrderTests
    {
        [Fact]
        private void Test_OrderExists()
        {
            var sut = new Order();
            Order sut1 = new Order();

            var actual = sut;

            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_OrderComputePricingExists()
        {
            var sut = new Order();
            Order sut1 = new Order();

            var actual = sut;

            Assert.IsType<Order>(actual);
            Assert.Equal<decimal>(0M,actual.ComputePricing());
        }

        [Fact]
        private void Test_OrderLimitCheckExists()
        {
            var sut = new Order();
            Order sut1 = new Order();

            var actual = sut;

            Assert.IsType<Order>(actual);
            Assert.False(actual.LimitCheck());
        }
    }
}
