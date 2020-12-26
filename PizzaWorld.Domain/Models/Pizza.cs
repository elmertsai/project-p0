using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
  public class Pizza : APizzaModel
  {    
    public Pizza(Crust c, Size s,List<Topping> t)
    {
      this.crust = c;
      this.size = s;
      this.toppings = t;
      this.price = CalculatePrice(c,s,t);
    }
    public void SetName(string n)
    {
      this.name = n;
    }
    public double CalculatePrice(Crust c, Size s,List<Topping> t)
    {
      double sum=0;
      foreach (var item in t)
      {
          sum += item.price;
      }
      sum += s.price;
      sum += c.price;
      return sum;
    }
  }
}
