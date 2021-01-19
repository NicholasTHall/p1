using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.WebClient.Models
{
  public class PizzaViewModel
  {
    public string PizzaType {get; set;}
    public string PizzaCrust {get; set;}
    public string PizzaSize {get; set;}
    public List<PizzaTopping> PizzaToppings {get; set;}
    public decimal Price {get; set;}
  }
}
