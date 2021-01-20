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
    public IActionResult OrderHistory(CustomerViewModel model)
    {
      var store = new StoreViewModel()
      {
        Name = model.Name,
        Orders = _ctx.GetOneStore(model.Name).Orders
      };
      return View(store);
    }
  }
}
