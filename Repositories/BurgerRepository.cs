using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.db;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    // private readonly FakeDB _db;

    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }


    //GET ALL REQ
    public IEnumerable<Burger> GetAll()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }

    public Burger GetBurgerById(int id)
    {
      return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    public Burger AddBurger(Burger newBurger)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO burgers 
     (name, description, price)
      VALUES(@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();", newBurger
      );
      if (id == 0)
      {
        return null;
      }
      newBurger.Id = id;
      return newBurger;

    }

    public Burger EditBurger(int id, Burger newBurger)
    {
      try
      {
        FakeDB.Burgers[id] = newBurger;
        return newBurger;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteBurger(int id)
    {
      int success = _db.Execute(@"DELETE FROM bugers WHERE id= @id", new { id });
      if (success == 0) return false;
      return true;
    }
  }
}