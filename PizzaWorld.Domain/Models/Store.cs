
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class Store
    {
        public List<Order> Orders {get;set;}
        public void CreateOrder()
        {
            Orders.Add(new Order());
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
    }
}