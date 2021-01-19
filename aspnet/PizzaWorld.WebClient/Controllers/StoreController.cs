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
    public IActionResult Home()
    {
      var store = new StoreViewModel();
      store.Name = _ctx.GetOneStore("Two").Name;
      store.Orders = _ctx.GetStoreOrders("Two");

      return View("home", store);
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
