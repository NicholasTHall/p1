using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.WebClient.Models
{
  public class CustomerViewModel
  {
    public OrderViewModel Order { get; set; }
    public IList<Order> Orders { get; set; }
    public string SelectedStore { get; set; }
    public string Name { get; set; }
  }
}
