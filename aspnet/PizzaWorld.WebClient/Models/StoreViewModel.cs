using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.WebClient.Models
{
  public class StoreViewModel
  {
    public List<Order> Orders { get; set; }
    public string Name { get; set; }
  }
}
