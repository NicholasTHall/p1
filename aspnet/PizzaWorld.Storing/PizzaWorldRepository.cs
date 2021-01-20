using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{
  public class PizzaWorldRepository
  {
    private PizzaWorldContext _ctx;

    public void Update()
    {
        _ctx.SaveChanges();
    }

    public PizzaWorldRepository(PizzaWorldContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }

    public Store GetOneStore(string name)
    {
      return _ctx.Stores.Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                        .FirstOrDefault<Store>(s => s.Name == name);
    }

    public List<Order> GetStoreOrders(string name)
    {
      return _ctx.Stores.Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                        .FirstOrDefault<Store>(s => s.Name == name).Orders;
    }

    public Store GetStoreByUser(User user)
    {
      Store Store = _ctx.Users.FirstOrDefault<User>(u => u.Name == user.Name).SelectedStore;
      if(Store != null){return Store;}
      return _ctx.Stores.Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                        .FirstOrDefault<Store>(s => s.EntityId == 1);
    }

    public IEnumerable<User> GetUsers()
    {
      return _ctx.Users;
    }
    public User GetOneUser(string name)
    {
      return _ctx.Users.Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                       .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                       .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                       .FirstOrDefault<User>(u => u.Name == name);
    }

    public List<Order> GetUserOrders(string name)
    {
      return _ctx.Users.Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                       .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                       .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                       .FirstOrDefault<User>(u => u.Name == name).Orders;
    }

    public void AddUser(User user)
    {
            _ctx.Add(user);
            _ctx.SaveChanges();
    }

    // public IEnumerable<T> Get<T>() where T : AModel
    // {
    //   return _ctx.Set<T>().Select(t => t.GetType().GetProperty()).ToList();
    // }
  }
}
