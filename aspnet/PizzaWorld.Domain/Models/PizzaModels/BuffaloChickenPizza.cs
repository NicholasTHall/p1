using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Models.PizzaModels
{
    public class BuffaloChickenPizza : APizzaModel
    {
        protected override void AddPizzaType()
        {
            PizzaType = this.GetType().Name;
        }

        protected override void AddCrust()
        {
            PizzaCrust = new PizzaCrust();
            PizzaCrust.SelectCrust();
        }

        protected override void AddSize()
        {
            PizzaSize = new PizzaSize();
            PizzaSize.SelectSize();
        }

        protected override void AddToppings()
        {
            PizzaToppings.Add(new PizzaTopping("Sauce"));
            PizzaToppings.Add(new PizzaTopping("Cheese"));
            PizzaToppings.Add(new PizzaTopping("Chicken"));
            PizzaToppings.Add(new PizzaTopping("Onions"));
        }

        protected override void CalculatePrice()
        {
            Price = new PizzaPrice().CalculatePrice(PizzaCrust.Crust, PizzaSize.Size, PizzaToppings.Count);
        }
    }
}
