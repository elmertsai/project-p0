using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<APizzaModel> Pizzas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=elmerpizzaworlddb.database.windows.net,1433;Initial Catalog=PizzaWorldDB;User ID=;Password=Ppp12312344;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityID);
            builder.Entity<User>().HasKey(u => u.EntityID);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityID);
            builder.Entity<Order>().HasKey(o => o.EntityID);
            builder.Entity<Crust>().HasKey(c => c.EntityID);
            builder.Entity<Topping>().HasKey(t => t.EntityID);
            builder.Entity<Size>().HasKey(size => size.EntityID);


            SeedData(builder);
        }
        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
            {
            new Store() { Name = "One", Address = "Store 1 Address"},
            new Store() { Name = "Two", Address = "Store 2 Address"}
            }
            );
            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust() { name = "Thin",price = 0},
                new Crust() { name = "Hand Tossed",price = 0},
                new Crust() { name = "Cheese-Stuffed",price = 2}
            }
            );
            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size() { name = "Small",price = 0},
                new Size() { name = "Medium",price = 3},
                new Size() { name = "Large",price = 5}
            }
            );
            builder.Entity<Topping>().HasData(new List<Topping>
            {
                new Topping() { name = "Cheese",price = 0},
                new Topping() { name = "Premium Chicken",price = 2},
                new Topping() { name = "Pulled Pork",price = 2},
                new Topping() { name = "Mushroom",price = 0}
            }
            );
        }
    }
}