using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            var sut = new User();
            User sut1 = new User();

            var actual = sut;

            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_UserOrderHistoryExist()
        {
            var sut = new User();
            User sut1 = new User();

            var actual = sut;

            Assert.IsType<User>(actual);
            Assert.NotNull(actual.OrderHistory());
        }

        [Fact]
        private void Test_UserOrderSummaryExist()
        {
            var sut = new User();
            User sut1 = new User();

            var actual = sut;

            Assert.IsType<User>(actual);
            Assert.NotNull(actual.OrderSummmary());
        }

        [Fact]
        private void Test_UserOrderTimeLimitCheckExist()
        {
            var sut = new User();
            User sut1 = new User();

            var actual = sut;

            Assert.IsType<User>(actual);
            Assert.False(actual.OrderTimeLimitCheck());
        }

        [Fact]
        private void Test_UserStoreChangeCheckExist()
        {
            var sut = new User();
            User sut1 = new User();

            var actual = sut;

            Assert.IsType<User>(actual);
            Assert.False(actual.StoreChangeCheck());
        }
    }
}
