using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  [Route("/[controller]/[action]")]
  [EnableCors("private")]
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }
    
    public IActionResult Start()
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid) //  what is the validation? (add to viewmodel)
      {
        var p = new PizzaFactory(); // use dependency injection
        
        //p.Create(pizzaViewModel);
        //repository.Create(pizzaViewModel);

        //return View("User");
        return Redirect("/user/index"); // http 300-series status
      }

      return View("Order", pizzaViewModel);
    }

    // http status
    /*
    - 100-series = network
    - 200-series = all is good, 200-ok, 201-modified, 202-notmodified
    - 300-series = redirection, temporary, permanent
    - 400-series = user is stupid, client error
    - 500-series = dev is stupid, server error
    */
  }
}
