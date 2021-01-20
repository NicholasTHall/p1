using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Models.PizzaModels;
using PizzaWorld.Storing;
using PizzaWorld.WebClient.Models;
using PizzaWorld.Domain.Models.PizzaComponents;

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
    public IActionResult Home(CustomerViewModel model)
    {
      var user = _ctx.GetOneUser(model.Name);
      var customer = new CustomerViewModel();
      customer.Name = user.Name;
      customer.SelectedStore = _ctx.GetOneStore("One").Name;
      customer.Orders = user.Orders;
      customer.Order = new OrderViewModel()
      {
        Pizzas = new List<APizzaModel>()
      };

      return View("Home", customer);
    }

    [HttpGet]
    public IActionResult SelectStore(CustomerViewModel model)
    {
      var user = _ctx.GetOneUser(model.Name);
      var customer = new CustomerViewModel();
      customer.Name = user.Name;
      customer.SelectedStore = _ctx.GetOneStore(model.SelectedStore).Name;
      customer.Orders = user.Orders;
      customer.Order = new OrderViewModel()
      {
        Pizzas = new List<APizzaModel>()
      };

      return View("Home", customer);
    }

    [HttpGet]
    public IActionResult SelectCustomer()
    {
      return View();
    }

    [HttpPost]
    public IActionResult SelectCustomer(CustomerViewModel model)
    {
      var customer = _ctx.GetOneUser(model.Name);
      if (customer == null)
      {
        ModelState.AddModelError(string.Empty, "Invalid Customer Name.");
        return View();
      }
      else
      {
        return RedirectToAction("Home", model);
      }
    }

    [HttpGet]
    public IActionResult NewCustomer()
    {
      return View();
    }

    [HttpGet]
    public IActionResult CreateOrder(CustomerViewModel model)
    {
      var customer = new CustomerViewModel()
      {
        Name = model.Name,
        SelectedStore = model.SelectedStore,
        Orders = _ctx.GetOneUser(model.Name).Orders,
        Order = new OrderViewModel()
        {
          Customer = model.Name,
          Store = model.SelectedStore,
          Pizzas = new List<APizzaModel>(),
          Pizza = new PizzaViewModel()
        }
      };
      return View("MakeOrder", customer);
    }

    [HttpGet]
    public IActionResult MakeOrder(CustomerViewModel model)
    {
      var customer = model;

      return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPizza(CustomerViewModel model)
    {
      if (ModelState.IsValid)
      {
        var pizza = new WebPizza()
        {
          PizzaType = model.Order.Pizza.PizzaType,
          PizzaCrust = new PizzaCrust(model.Order.Pizza.PizzaCrust),
          PizzaSize = new PizzaSize(model.Order.Pizza.PizzaSize),
          PizzaToppings = new List<PizzaTopping>()
        };
        pizza.PizzaToppings.Add(new PizzaTopping("cheese"));
        pizza.CalPrice();

        var customer = model;
        customer.Order.Pizzas.Add(pizza);

        return View("MakeOrder", customer);
      }
      ModelState.AddModelError(string.Empty, "Error something went wrong");
      return View("~/Views/Home/Index.cshtml");
    }

    [HttpGet]
    public IActionResult OrderHistory(CustomerViewModel model)
    {
      var customer = new CustomerViewModel()
      {
        Name = model.Name,
        Orders = _ctx.GetOneUser(model.Name).Orders
      };
      return View(customer);
    }

    [HttpPost]
    public IActionResult AddNewCustomer(CustomerViewModel model)
    {
      if (ModelState.IsValid)
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
