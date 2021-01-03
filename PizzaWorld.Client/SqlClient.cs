
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Abstracts;
using PizzWorld.Storing;
using Microsoft.EntityFrameworkCore;

namespace PizzaWorld.Client
{

    public class SqlClient
    {
            private readonly PizzaWorldContext _context = new PizzaWorldContext();
        public SqlClient()
    {
      if (ReadStores().Count() == 0)
      {
        CreateStore();
      }
    }

//Create a new empty store
        private void CreateStore()
        {
            Save(new Store());
        }

// Return the list of stores
    public IEnumerable<Store> ReadStores()
    {
        return _context.Stores.ToList();
    }
    public IEnumerable<APizzaModel> ReadPizzas()
    {
        return _context.Pizzas.ToList();
    }
    public IEnumerable<Crust> ReadCrust()
    {
        return _context.Crusts.ToList();
    }
    public IEnumerable<Topping> ReadTopping()
    {
        return _context.Toppings.ToList();
    }
    public void UserOrderHistory(User user)
    {
        var u = _context.Users
                        .Include(u => u.Orders)
                        .ThenInclude(o=> o.Pizzas)
                        .ThenInclude(p => p.crust)
                        // .ThenInclude(p => p.toppings) why is it not there
                        .FirstOrDefault(u => u.EntityID == user.EntityID);
    }
    public IEnumerable<Size> ReadSize()
    {
        return _context.Sizes.ToList();
    }        
//Save a store to the database
    public void Save(Store store)
    {
    _context.Stores.Add(store); //git add
    _context.Database.OpenConnection();
    try
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Stores ON");
        _context.SaveChanges();
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Stores OFF");
    }
    finally
    {
        _context.Database.CloseConnection();
    }
    }
    public void Save(Order order)
    {
        _context.Add(order);
    try
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders ON");
        _context.SaveChanges();
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders OFF");
    }
    finally
    {
        _context.Database.CloseConnection();
    }
    }
    public void Save(APizzaModel pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.Database.OpenConnection();
    try
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizzas ON");
        _context.SaveChanges();
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizzas OFF");
    }
    finally
    {
        _context.Database.CloseConnection();
    }
    }
    //Save changes to the database
    public void Update()
    {
        _context.SaveChanges();
    }
    }

}