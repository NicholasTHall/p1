using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Models.PizzaModels
{
    public class WebPizza : APizzaModel
    {
        public void CalPrice()
        {
            Price = new PizzaPrice().CalculatePrice(PizzaCrust.Crust, PizzaSize.Size, PizzaToppings.Count);
        }
    }
}
