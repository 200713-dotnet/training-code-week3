using System.Collections.Generic;
using PizzaStore.Domain.Factories;

namespace PizzaStore.Domain.Models
{
  public class StoreModel
  {
    private IFactory _factory;
    private static StoreModel _store;
     
    private StoreModel(IFactory factory)
    {
      _factory = factory;
    }

    public static StoreModel Instance(IFactory factory)
    {
      if (_store == null || _store._factory.GetType().Name != factory.GetType().Name)
      {
        _store = new StoreModel(factory);
      }

      return _store;
    }

    public void CreateOrder()
    {
      AModel pm = _factory.Create();
    }
  }
}
