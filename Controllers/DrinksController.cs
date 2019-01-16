using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {

    private readonly DrinksRepository _drinkRepo;

    public DrinksController(DrinksRepository drinkRepo)
    {
      _drinkRepo = drinkRepo;
    }

    // GET api/Drinks
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      return Ok(_drinkRepo.GetAll());
    }

    // GET api/Drinks/5
    [HttpGet("{id}")]
    public ActionResult<Drink> Get(int id)
    {
      Drink result = _drinkRepo.GetDrinkById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/Drinks
    [HttpPost]
    public ActionResult<List<Drink>> Post([FromBody] Drink drink)
    {
      return Created("/api/drinks/",
      _drinkRepo.AddDrink(drink));
    }

    // PUT api/Drinks/5
    [HttpPut("{id}")]
    public ActionResult<List<Drink>> Put(int id, [FromBody] Drink drink)
    {
      Drink result = _drinkRepo.EditDrink(id, drink);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/Drinks/5
    [HttpDelete("{id}")]
    public ActionResult<List<Drink>> Delete(int id)
    {
      try
      {
        Drinks.Remove(Drinks[id]);
        return Drinks;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH DRINK\"}");
      }
    }

  }
}