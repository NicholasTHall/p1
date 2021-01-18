using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            var sut = new Store();
            Store sut1 = new Store();

            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_StoreWeeklyPizzaStatsExists()
        {
            var sut = new Store();
            Store sut1 = new Store();

            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual.WeeklyPizzaStats());
        }

        [Fact]
        private void Test_StoreWeeklyRevenueExists()
        {
            var sut = new Store();
            Store sut1 = new Store();

            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual.WeeklyRevenue());
        }

        [Fact]
        private void Test_StoreMonthlyPizzaStatsExists()
        {
            var sut = new Store();
            Store sut1 = new Store();

            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual.MonthlyPizzaStats());
        }

        [Fact]
        private void Test_StoreMonthlyRevenueExists()
        {
            var sut = new Store();
            Store sut1 = new Store();

            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual.MonthlyRevenue());
        }
    }
}
