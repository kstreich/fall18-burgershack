using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.db;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class DrinksRepository
  {
    // private readonly FakeDB _db;

    private readonly IDbConnection _db;

    public DrinksRepository(IDbConnection db)
    {
      _db = db;
    }


    //GET ALL REQ
    public IEnumerable<Drink> GetAll()
    {
      return _db.Query<Drink>("SELECT * FROM Drinks");
    }

    public Drink GetDrinkById(int id)
    {
      return _db.QueryFirstOrDefault<Drink>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    public Drink AddDrink(Drink newDrink)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO drinks 
     (name, description, price)
      VALUES(@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();", newDrink
      );
      if (id == 0)
      {
        return null;
      }
      newDrink.Id = id;
      return newDrink;

    }

    public Drink EditDrink(int id, Drink newDrink)
    {
      try
      {
        return _db.QueryFirstOrDefault<Drink>($@"
        UPDATE Drink SET
          Price = @Price,
          Description = @Description,
          Name = @Name
        WHERE Id = @Id;
        SELECT * FROM Drinks Where id= @Id", newDrink);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteDrink(int id)
    {
      int success = _db.Execute(@"DELETE FROM drinks WHERE id= @id", new { id });
      if (success == 0) return false;
      return true;
    }
  }
}