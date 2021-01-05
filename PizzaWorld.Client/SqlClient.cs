
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
    //   if (ReadStores().Count() == 0)
    //   {
    //     CreateStore();
    //   }
    }

//Create a new empty store
        // private void CreateStore()
        // {
        //     Save(new Store());
        // }

// Return the list of stores
    public IEnumerable<Store> ReadStores()
    {

        return _context.Stores.Include(s=>s.Orders);
 
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
    public IEnumerable<User> ReadUsers()
    {
        var us = _context.Users
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.Pizzas)
                    .ToList();
        return us;
    }
    public IEnumerable<Order> OrderHistoryByUser(User user)
    {
        return _context.Orders.Where(o=>o.User.Name==user.Name);

    }
    public IEnumerable<Order> OrderHistoryByStore(Store store)
    {
        return _context.Orders.Where(o=>o.Store.Name==store.Name);

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
        _context.SaveChanges();
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
        _context.SaveChanges();
    }
    finally
    {
        _context.Database.CloseConnection();
    }
    }
    public void Save(User user)
    {
        _context.Users.Add(user);
        _context.Database.OpenConnection();
        try
        {
            _context.SaveChanges();
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
        _context.SaveChanges();
    }
    finally
    {
        _context.Database.CloseConnection();
    }
    }
    // Save changes to the database
    public void UpdateUser(User user)
    {
        var u =  _context.Users.ToList().FirstOrDefault(x => x.Name==user.Name);
        if(u==null)
        {
            System.Console.WriteLine("Warning... username not found in db");
        }
        else
        {
            u.Orders = user.Orders;
            u.SelectedStore = user.SelectedStore;
            _context.SaveChanges();
        }
    }
    public void UpdateStore(Store store)
    {
        var s =  _context.Stores.ToList().FirstOrDefault(x => x.EntityID==store.EntityID);
        if(s==null)
        {
            System.Console.WriteLine("Warning... store not found in db");
        }
        else
        {
            s.Orders = store.Orders;
            _context.SaveChanges();
        }
    }
    public void Update()
    {
        _context.SaveChanges();
    }

    }

}