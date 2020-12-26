using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Abstracts
{
  public class APizzaModel : AProduct
  {
    public Crust crust { get; set; }
    public Size size { get; set; }
    public List<Topping> toppings { get; set; }

  }
}
