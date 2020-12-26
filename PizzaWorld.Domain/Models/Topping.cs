using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
  public class Topping : AEntity
  {
    public string name { get; set; }
    public double price { get; set; }

  }
}
