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
                new Store() { Name = "One"},
                new Store() { Name = "Two"}
            }
            );
        }
    }
}