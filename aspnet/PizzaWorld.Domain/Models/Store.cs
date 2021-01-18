using System;
using System.Collections.Generic;
using System.Text;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
  public class Store : AEntity
  {
    public List<Order> Orders { get; set; }
    public string Name { get; set; }

    public Store()
    {
      Orders = new List<Order>();
    }
    public void CreateOrder()
    {
      Orders.Add(new Order());
    }

    bool DeleteOrder(Order order)
    {
      try
      {
        Orders.Remove(order);

        return true;
      }
      catch
      {
        return false;
      }
    }

    public string WeeklyRevenue()
    {
      decimal revenue = 0;
      DateTime start = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - DayOfWeek.Sunday));
      DateTime end = start.AddDays(6);
      foreach (var o in Orders)
      {
        if (o.OrderDate.CompareTo(start) >= 0 && o.OrderDate.CompareTo(end) <= 0)
        {
          revenue += o.ComputePricing();
        }
      }

      return $"Weekly Revenue is: {revenue}";
    }

    public string WeeklyPizzaStats()
    {
      Dictionary<string, int> pizzaSold = new Dictionary<string, int>();
      int totalPizzaSold = 0;
      var sb = new StringBuilder();
      DateTime start = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - DayOfWeek.Sunday));
      DateTime end = start.AddDays(6);
      foreach (var o in Orders)
      {
        if (o.OrderDate.CompareTo(start) >= 0 && o.OrderDate.CompareTo(end) <= 0)
        {
          foreach (var p in o.Pizzas)
          {
            if (pizzaSold.ContainsKey(p.PizzaType))
            {
              pizzaSold[p.PizzaType] += 1;
            }
            else
            {
              pizzaSold.TryAdd(p.PizzaType, 1);
            }
          }
        }
      }

      foreach (var value in pizzaSold)
      {
        totalPizzaSold += value.Value;
        sb.AppendLine($"Sold {value.Value} of Pizza type {value.Key}");
      }
      return $"Weekly pizza sales:\n{sb.ToString()}Total pizzas sold this week is: {totalPizzaSold}";
    }

    public string MonthlyRevenue()
    {
      decimal revenue = 0;
      foreach (var o in Orders)
      {
        if (o.OrderDate.Month.Equals(DateTime.Now.Month))
        {
          revenue += o.ComputePricing();
        }
      }

      return $"Monthly Revenue is: {revenue}";
    }

    public string MonthlyPizzaStats()
    {
      Dictionary<string, int> pizzaSold = new Dictionary<string, int>();
      int totalPizzaSold = 0;
      var sb = new StringBuilder();

      foreach (var o in Orders)
      {
        if (o.OrderDate.Month.Equals(DateTime.Now.Month))
        {
          foreach (var p in o.Pizzas)
          {
            if (pizzaSold.ContainsKey(p.PizzaType))
            {
              pizzaSold[p.PizzaType] += 1;
            }
            else
            {
              pizzaSold.TryAdd(p.PizzaType, 1);
            }
          }
        }
      }

      foreach (var value in pizzaSold)
      {
        totalPizzaSold += value.Value;
        sb.AppendLine($"Sold {value.Value} of Pizza type {value.Key}");
      }
      return $"Monthly pizza sales:\n{sb.ToString()}Total pizzas sold this month is: {totalPizzaSold}";
    }

    public string OrderHistory()
    {
      var sb = new StringBuilder();

      int cnt = 0;
      foreach (var o in Orders)
      {
        cnt += 1;
        sb.AppendLine($"Order {cnt} {o.ToString()}");
      }

      return $"order history: \n{sb.ToString()}";
    }

    public string UserOrderHistory(User user)
    {
      var sb = new StringBuilder();

      int cnt = 0;
      foreach (var so in Orders)
      {
        foreach(var uo in user.Orders)
        {
          if(so.EntityId == uo.EntityId){
            cnt += 1;
            sb.AppendLine($"Order {cnt} {so.ToString()}");
          }
        }
      }

      return $"order history: \n{sb.ToString()}";
    }

    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
