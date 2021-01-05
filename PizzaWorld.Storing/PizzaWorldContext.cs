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
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<APizzaModel> Pizzas { get; set; }
        public DbSet<Order> Orders {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=elmerpizzaworlddb.database.windows.net;Initial Catalog=PizzaWorldDB;User ID=sqladmin;Password=Ppp12312344;");
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
            new Store() { Name = "One", Address = "Store 1 Address", EntityID =1},
            new Store() { Name = "Two", Address = "Store 2 Address", EntityID =2}
            }
            );
            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust() { name = "Thin",price = 0,EntityID=1},
                new Crust() { name = "Hand Tossed",price = 0,EntityID=2},
                new Crust() { name = "Cheese-Stuffed",price = 2,EntityID=3}
            }
            );
            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size() { name = "Small",price = 0,EntityID=1},
                new Size() { name = "Medium",price = 3,EntityID =2},
                new Size() { name = "Large",price = 5,EntityID =3}
            }
            );
            builder.Entity<Topping>().HasData(new List<Topping>
            {
                new Topping() { name = "Cheese",price = 0,EntityID=1},
                new Topping() { name = "Premium Chicken",price = 2,EntityID=2},
                new Topping() { name = "Pulled Pork",price = 2,EntityID=3},
                new Topping() { name = "Mushroom",price = 0,EntityID=4}
            }
            );
            builder.Entity<User>().HasData(new List<User>
            {
                new User() { Name = "Elmer",EntityID=1},
                new User() { Name = "Elmer2",EntityID=2},
                new User() { Name = "user3",EntityID=3}
            }
            );
        }
    }
}