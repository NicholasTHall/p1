using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
  public class User : AEntity
  {
    public List<Order> Orders { get; set; }
    public Store SelectedStore { get; set; }
    public string Name { get; set; }

    public User()
    {
      Orders = new List<Order>();
    }

    public bool OrderTimeLimitCheck()
    {
      if (!Orders.Any())
      {
        return false;
      }

      if (Orders.Last().OrderDate.AddHours(2).CompareTo(DateTime.Now) > 0)
      {
        return true;
      }

      return false;
    }

    public bool StoreChangeCheck()
    {
      if (!Orders.Any())
      {
        return false;
      }

      if (Orders.Last().OrderDate.AddDays(1).CompareTo(DateTime.Now) > 0)
      {
        return true;
      }
      return false;
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

    public string OrderSummmary()
    {
      if (!Orders.Any())
      {
        return $"No order created yet";
      }
      return $"You have selected this store {SelectedStore} and {Orders.Last().ToString()}";
    }
  }
}
