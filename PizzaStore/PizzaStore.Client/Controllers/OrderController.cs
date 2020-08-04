using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    public IActionResult Home()
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid) //  what is the validation? (add to viewmodel)
      {
        var p = new PizzaFactory(); // use dependency injection
        
        //p.Create(pizzaViewModel);
        //repository.Create(pizzaViewModel);

        return View("User");
      }

      return View("Order", pizzaViewModel);
    }
  }
}
