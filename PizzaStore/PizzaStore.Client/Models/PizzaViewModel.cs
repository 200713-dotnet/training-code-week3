using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class PizzaViewModel
  {
    // out to the client
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }


    // in from the client
    [Required(ErrorMessage = "Better select Crust")]
    public string Crust { get; set; }
    [Required]
    public string Size { get; set; }
    [Range(2,5)]
    public List<string> SelectedToppings { get; set; }
    public bool SelectedTopping { get; set; }

    public PizzaViewModel()
    {
      Crusts = new List<CrustModel>() { new CrustModel() { Name = "Chicago" }};
      Sizes = new List<SizeModel>() { new SizeModel() { Name = "Medium" }};
      Toppings = new List<ToppingModel>() { new ToppingModel(){ Name = "Pepperoni" }};
    }
  }
}
