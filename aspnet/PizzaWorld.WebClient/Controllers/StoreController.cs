using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storing;
using PizzaWorld.WebClient.Models;

namespace PizzaWorld.WebClient.Controllers
{
  public class StoreController : Controller
  {
    private readonly PizzaWorldRepository _ctx;
    public StoreController(PizzaWorldRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home(StoreViewModel model)
    {
      var store = new StoreViewModel();
      store.Name = model.Name;
      store.Orders = _ctx.GetStoreOrders(model.Name);

      return View("home", store);
    }

    [HttpGet]
    public IActionResult SelectStore()
    {
      return View();
    }

    [HttpPost]
    public IActionResult SelectStore(StoreViewModel model)
    {
      var store = _ctx.GetOneStore(model.Name);
      if (store == null)
      {
        ModelState.AddModelError(string.Empty, "Invalid Store Name.");
        return View();
      }
      else
      {
        return RedirectToAction("Home", model);
      }
    }

    [HttpGet]
    public IActionResult OrderHistory(StoreViewModel model)
    {
      var store = new StoreViewModel()
      {
        Name = model.Name,
        Orders = _ctx.GetOneStore(model.Name).Orders
      };
      return View(store);
    }

    [HttpGet]
    public IActionResult Sales(StoreViewModel model)
    {
      var store = model;

      return View(store);
    }

    [HttpGet]
    public IActionResult WeeklySales(StoreViewModel model)
    {
      var store = model;
      var ctxStore = _ctx.GetOneStore(model.Name);
      store.PizzaStats = ctxStore.WeeklyPizzaStats();
      store.Revenue = ctxStore.WeeklyRevenue();

      return View("Sales",store);
    }

    [HttpGet]
    public IActionResult MonthlySales(StoreViewModel model)
    {
      var store = model;
      var ctxStore = _ctx.GetOneStore(model.Name);
      store.PizzaStats = ctxStore.MonthlyPizzaStats();
      store.Revenue = ctxStore.MonthlyRevenue();

      return View("Sales",store);
    }
  }
}
