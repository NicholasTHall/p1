using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.WebClient.Models
{
  public class CustomerViewModel
  {
    public OrderViewModel Order { get; set; }
    public Store SelectedStore { get; set; }
    public string Name { get; set; }
  }
}