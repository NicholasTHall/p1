using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Models.PizzaModels;
using PizzaWorld.Storing;
using PizzaWorld.WebClient.Models;
using PizzaWorld.Domain.Factories;

namespace PizzaBox.WebClient.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaWorldRepository _ctx;
    public OrderController(PizzaWorldRepository context)
    {
      _ctx = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {


        return View("~/Views/Home/Index.cshtml");
      }

      return View("home", model);
    }
  }
}
