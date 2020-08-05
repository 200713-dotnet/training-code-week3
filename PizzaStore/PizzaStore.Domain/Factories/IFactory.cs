using PizzaStore.Domain.Models;

namespace PizzaStore.Domain.Factories
{
  public interface IFactory
  {
    AModel Create();
  }
}
