
using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Store : AEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders {get;set;}
        public Store()
        {
            Name = "Default Name";
            Address = "Default Address";
        }
        public void CreateOrder()
        {
            Order o = new Order();
            Orders.Add(o);
            // System.Console.WriteLine(Orders.Count);
            // System.Console.WriteLine(o);
        }

        public bool DeleteOrder(Order order)
        {
            
            try
            {
                Orders.Remove(order);
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
           

        }
        public override string ToString()
        {
            return String.Format("{0,-10} {1,-10}",Name,Address);
        }
    }
}