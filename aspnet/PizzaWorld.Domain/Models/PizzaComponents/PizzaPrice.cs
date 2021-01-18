using System;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaPrice
    {
        public decimal CalculatePrice(String crust, String size, int toppings)
        {
            decimal price = 0;

            price += CalculateCrustPrice(crust);
            price += CalculateSizePrice(size);
            price += CalculateToppingsPrice(toppings);

            return price;
        }

        public decimal CalculateCrustPrice(String crust)
        {
            switch(crust)
            {
                case "Regular":
                    return 1.00M;
                case "Thin":
                    return 0.75M;
                case "Cheese Fill":
                    return 1.50M;
                case "Gluten Free":
                    return 2.00M;
                default:
                    return 1.00M;
            }
        }

        public decimal CalculateSizePrice(String size)
        {
            switch(size)
            {
                case "Small":
                    return 11.00M;
                case "Medium":
                    return 11.50M;
                case "Large":
                    return 12.00M;
                case "Extra Large":
                    return 12.50M;
                default:
                    return 11.50M;
            }
        }

        public decimal CalculateToppingsPrice(int toppings)
        {
            return 0.50M * toppings;
        }
    }
}
