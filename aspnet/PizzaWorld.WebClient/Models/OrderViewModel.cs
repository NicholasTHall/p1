using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.WebClient.Models
{
  public class OrderViewModel
  {
    public List<APizzaModel> Pizzas { get; set; }
    public DateTime OrderDate { get; set; }
  }
}