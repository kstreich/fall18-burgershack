using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.db;
using BurgerShack.Models;
using Dapper;
//all of your database methods live in here in your REPO's :)

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
      //QUERY is from dapper
    }


    //GET by Id
    public Burger GetBurgerById(int id)
    {
      return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    //POST 
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
        return _db.QueryFirstOrDefault<Burger>($@"
        UPDATE Burger SET
          Price = @Price,
          Description = @Description,
          Name = @Name
        WHERE Id = @Id;
        SELECT * FROM Burgers Where id= @Id", newBurger);
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