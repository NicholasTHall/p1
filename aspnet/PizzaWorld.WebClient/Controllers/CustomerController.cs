using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;
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
      customer.Name =  _ctx.GetOneUser("UserOne").Name;
      customer.SelectedStore = _ctx.GetOneStore("One");
      customer.Orders = _ctx.GetOneUser("UserOne").Orders;
      customer.Order = new OrderViewModel()
      {
        Pizzas = _ctx.GetOneUser("Nick").Orders.Last().Pizzas
      };

      return View("home", customer);
    }

    [HttpGet]
    public IActionResult NewCustomer()
    {
      return View();
    }

    [HttpPost]
    public IActionResult AddNewCustomer(CustomerViewModel model)
    {
      if(ModelState.IsValid)
      {
        var user = new User()
        {
          Name = model.Name
        };

        _ctx.AddUser(user);
      }

      return View("~/Views/Home/Index.cshtml");
    }
  }
}
