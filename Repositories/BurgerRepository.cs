using System;
using System.Collections.Generic;
using BurgerShack.db;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    // private readonly FakeDB _db;
    public IEnumerable<Burger> GetAll()
    {
      return FakeDB.Burgers;
    }

    public Burger GetBurgerById(int id)
    {
      try
      {
        return FakeDB.Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public Burger AddBurger(Burger newBurger)
    {
      FakeDB.Burgers.Add(newBurger);
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
      try
      {
        FakeDB.Burgers.Remove(FakeDB.Burgers[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }

  }
}