using PizzaWorld.Domain.Models.PizzaComponents;
using PizzaWorld.Domain.Models.PizzaModels;
using Xunit;

namespace PizzaWorld.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_PizzaCrustExists()
        {
            var sut = new PizzaCrust();
            PizzaCrust sut1 = new PizzaCrust();

            var actual = sut;

            Assert.IsType<PizzaCrust>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_PizzaSizeExists()
        {
            var sut = new PizzaSize();
            PizzaSize sut1 = new PizzaSize();

            var actual = sut;

            Assert.IsType<PizzaSize>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_PizzaToppingExists()
        {
            var sut = new PizzaTopping();
            PizzaTopping sut1 = new PizzaTopping();

            var actual = sut;

            Assert.IsType<PizzaTopping>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_PizzaPriceExists()
        {
            var sut = new PizzaPrice();
            PizzaPrice sut1 = new PizzaPrice();

            var actual = sut;

            Assert.IsType<PizzaPrice>(actual);
            Assert.Equal<decimal>(12.50M,actual.CalculatePrice("","",0));
        }
    }
}
