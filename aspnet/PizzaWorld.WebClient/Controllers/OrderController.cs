using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;
using PizzaWorld.WebClient.Models;

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