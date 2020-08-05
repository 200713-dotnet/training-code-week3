namespace PizzaStore.Domain.Models
{
  public class TexasModel : AModel
  {
    public void IWantPizza()
    {
      var b = Brand.Instance();

      var p = b.PizzaFactory.Create();
    }
  }
}