using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<Store> Stores {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<APizzaModel> PizzaModels {get; set;}

        public PizzaWorldContext() {}
        public PizzaWorldContext(DbContextOptions<PizzaWorldContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);
            builder.Entity<PizzaTopping>().HasKey(t => t.EntityId);
            builder.Entity<PizzaCrust>().HasKey(c => c.EntityId);
            builder.Entity<PizzaSize>().HasKey(ps => ps.EntityId);

            SeedStoreData(builder);
            SeedUserData(builder);
        }

        private void SeedStoreData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData( new List<Store>
                {
                    new Store() {EntityId = 1, Name = "One"},
                    new Store() {EntityId = 2, Name = "Two"},
                    new Store() {EntityId = 3, Name = "Three"},
                    new Store() {EntityId = 4, Name = "Four"}
                }
            );
        }
        private void SeedUserData(ModelBuilder builder)
        {
            builder.Entity<User>().HasData( new List<User>
                {
                    new User() {EntityId = 1, Name = "UserOne"},
                    new User() {EntityId = 2, Name = "UserTwo"},
                    new User() {EntityId = 3, Name = "UserThree"},
                    new User() {EntityId = 4, Name = "UserFour"}
                }
            );
        }
    }
}
