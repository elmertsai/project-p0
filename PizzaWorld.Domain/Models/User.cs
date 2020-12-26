using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class User : AEntity
    {
        public List<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
        }
        public Store SelectedStore { get; set; }
        public override string ToString()
        {
            return $"I have selected this store: {SelectedStore}"; //$ String interpolation
        }
    
    }
}