using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using PizzaWorld.Domain.Models.PizzaModels;

namespace PizzaWorld.Domain.Models
{
  public class Order : AEntity
  {
    private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
    public List<APizzaModel> Pizzas { get; set; }
    public DateTime OrderDate { get; set; }

    public Order()
    {
      Pizzas = new List<APizzaModel>();
    }
    public bool DeletePizza(int index)
    {
      try
      {
        Pizzas.RemoveAt(index);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public decimal ComputePricing()
    {
      decimal price = 0;
      foreach (var pizza in Pizzas)
      {
        price += pizza.Price;
      }

      return price;
    }

    public bool LimitCheck()
    {
      const int maxPizzas = 50;
      const decimal maxBill = 250M;
      if (Pizzas.Count > maxPizzas || ComputePricing() > maxBill)
      {
        Console.WriteLine($"Order limit reached (max pizzas {maxPizzas}, max cost {maxBill}) pizza not added");
        Pizzas.RemoveAt(Pizzas.Count - 1);
        return true;
      }
      return false;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      int cnt = 0;
      foreach (var p in Pizzas)
      {
        cnt += 1;
        sb.Append($"\t{cnt}. {p.PizzaType}: {p.PizzaSize.Size} Size, {p.PizzaCrust.Crust} Crust with {p.PizzaToppings.Count} toppings: ");
        foreach (var t in p.PizzaToppings)
        {
          sb.Append($"[{t.Toppings}] ");
        }
        sb.Append($"at price {p.Price}\n");
      };

      return $"ordered pizzas:\n{sb.ToString()}Total price of order is: {ComputePricing()}";
    }

    public void MakeMeatPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
    }
    public void MakeBuffaloChickenPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<BuffaloChickenPizza>());
    }
    public void MakeGlutenFreePizza()
    {
      Pizzas.Add(_pizzaFactory.Make<GlutenFreePizza>());
    }
    public void MakeHawaiianPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<HawaiianPizza>());
    }
    public void MakePillyCheeseSteakPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<PillyCheeseSteakPizza>());
    }
    public void MakeCustomPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<CustomPizza>());
    }
  }
}
