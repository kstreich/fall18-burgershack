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

  //CREATE A NEW CONSTRUCTOR HERE to reference your repository, this ties into the transient service thing that you added into the startup. cs folder
  public class BurgersController : ControllerBase
  {
    private readonly BurgerRepository _burgerRepo;
    public BurgersController(BurgerRepository burgerRepo)
    {
      _burgerRepo = burgerRepo;
    }
    #region
    //THIS GETS CHANGED WHEN YOU ADD IN A DATE BASE
    // public List<Burger> Burgers = new List<Burger>()
    // {
    //   new Burger("Mark Burger", "A delicious burger with bacon and stuff", 7.56f),
    //   new Burger("Jake Burger", "Now with fries!", 8.54f),
    //   new Burger("D$ Burger", "It's Mostly Foraged", 6.24f)
    // };
    #endregion


    // GET api/Burgers
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      return Ok(_burgerRepo.GetAll());
    }

    // GET api/Burgers/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      Burger result = _burgerRepo.GetBurgerById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
      #region
      // try
      // {
      //   return Burgers[id];
      // }
      // catch (Exception ex)
      // {
      //   Console.WriteLine(ex);
      //   return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      // }
      #endregion
    }

    // POST api/Burgers
    [HttpPost]
    public ActionResult<List<Burger>> Post([FromBody] Burger burger)
    {
      return Created("/api/burger/", _burgerRepo.AddBurger(burger));

      //there's a different way to do this in the Library API project done in class


      #region
      //ALSO -- return ok(_burgerRepo.AddBurger(burger))

      // Burgers.Add(burger);
      // return Burgers;


      // int id = _db.ExecuteScalar<int>(@"
      // INSERT......; 
      // SELECT LAST_INSERT_ID()", new
      //     {
      //       burger.Name,
      //       burger.Description,
      //       burger.Price
      //     });
      //     burger.Id = id;
      //     return burger;
      #endregion
    }

    // PUT api/Burgers/5
    [HttpPut("{id}")]
    public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
    {
      Burger result = _burgerRepo.EditBurger(id, burger);
      if (result != null)
      {
        return result;
      }
      return NotFound();

      #region 
      // try
      // {
      //   Burgers[id] = burger;
      //   return Burgers;
      // }
      // catch (Exception ex)
      // {
      //   Console.WriteLine(ex);
      //   return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      // }
      #endregion
    }

    // DELETE api/Sides/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {

      if (_burgerRepo.DeleteBurger(id))
      {
        return Ok("success");
      }
      return BadRequest("No burger to delete");

      #region
      // try
      // {
      //   Burgers.Remove(Burgers[id]);
      //   return Burgers;
      // }
      // catch (Exception ex)
      // {
      //   Console.WriteLine(ex);
      //   return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      // }

      #endregion
    }

  }
}