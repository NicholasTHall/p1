using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.WebClient.Models
{
  public class PizzaViewModel
  {
    public string PizzaType {get; set;}
    public PizzaCrust PizzaCrust {get; set;}
    public PizzaSize PizzaSize {get; set;}
    public List<PizzaTopping> PizzaToppings {get; set;}
    public decimal Price {get; set;}
  }
}
