using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Domain.Factories
{
  public class PizzaFactory : IFactory
  {
    public AModel Create()
    {
      var p = new PizzaModel();

      p.Crust = new CrustModel();
      p.Size = new SizeModel();
      p.Toppings = new List<ToppingModel>{ new ToppingModel() };

      return p;
    }
  }
}
