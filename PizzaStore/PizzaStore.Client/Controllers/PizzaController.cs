using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  public class PizzaController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public PizzaController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    [HttpGet()] // action filters (authorization/authentication, action, resource, response, exception)
    public IActionResult Get()
    {
      //ViewData, TempData (dictionaries)
      ViewBag.PizzaList = _db.Pizzas.ToList(); //dynamic object
      // ViewData["PizzaList"] = _db.Pizzas.ToList();
      // TempData["PizzaList"] = _db.Pizzas.ToList();

      // var DummyViewBag = new object(); // strongly typed, type cannot change based on value
      // DummyViewBag = 2;
      // DummyViewBag = 'a';

      // dynamic DummyViewBag2 = 10; // dynamically typed, type changes based on value given
      // DummyViewBag2 = new object();
      // DummyViewBag2 = 'b';
      // DummyViewBag2.PizzaList = _db.Pizzas.ToList();


      return View("Home2", _db.Pizzas.ToList());
    }

    [HttpGet("{id}")]
    public PizzaModel Get(int id)
    {
      return _db.Pizzas.SingleOrDefault(p => p.Id == id);
    }
  }
}
