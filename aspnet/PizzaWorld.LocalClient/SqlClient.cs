using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.LocalClient
{
    public class SqlClient
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public void Update()
        {
            _db.SaveChanges();
        }

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public Store ReadOneStore(string name)
        {
            return _db.Stores.Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                             .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                             .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                             .FirstOrDefault<Store>(s => s.Name == name);
        }

        public void SaveStore(Store store)
        {
            _db.Add(store);
            _db.SaveChanges();
        }

        public Store SelectStore(){
            string input = Console.ReadLine();
            return ReadOneStore(input);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _db.Users;
        }
        public User ReadOneUser(string name)
        {
            return _db.Users.Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(c => c.PizzaCrust)
                            .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(ps => ps.PizzaSize)
                            .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(t => t.PizzaToppings)
                            .FirstOrDefault<User>(u => u.Name == name);
        }

        public User SelectUser(){
            string input = Console.ReadLine();
            return ReadOneUser(input);
        }

        public void SaveUser(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<APizzaModel> ReadPizzaModel()
        {
            return _db.PizzaModels;
        }

        public void SavePizzaModel(APizzaModel pizzaModel)
        {
            _db.Add(pizzaModel);
            _db.SaveChanges();
        }
    }
}
