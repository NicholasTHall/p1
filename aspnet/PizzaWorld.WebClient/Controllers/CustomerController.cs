using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storing;
using PizzaWorld.WebClient.Models;

namespace PizzaWorld.WebClient.Controllers
{
  public class CustomerController : Controller
  {
    private readonly PizzaWorldRepository _ctx;
    public CustomerController(PizzaWorldRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel();
      customer.Name =  _ctx.GetOneUser("Nick").Name;
      customer.SelectedStore = _ctx.GetOneStore("One");
      customer.Order = new OrderViewModel()
      {
        Pizzas = _ctx.GetOneUser("Nick").Orders.Last().Pizzas
      };

      return View("home", customer);
    }
  }
}