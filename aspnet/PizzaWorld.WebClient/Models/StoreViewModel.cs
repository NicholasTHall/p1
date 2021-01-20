using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.WebClient.Models
{
  public class StoreViewModel
  {
    public string PizzaStats {get; set;}
    public string Revenue {get; set;}
    public List<Order> Orders { get; set; }
    public string Name { get; set; }
  }
}
