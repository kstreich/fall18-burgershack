using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.db
{

  static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>()
  {
    new Burger("Mark Burger", "A delicious burger with bacon and stuff", 7.56f),
    new Burger("Jake Burger", "Now with fries!", 8.54f),
    new Burger("D$ Burger", "It's Mostly Foraged", 6.24f)
  };

    //   public List<Drink> Drinks = new List<Drink>()
    //   {
    //     new Drink("Soda", 1.50f),
    //     new Drink("Iced Tea", .85f),
    //     new Drink("Sports Drink", 1.85f)
    // };

    // public List<Side> Sides = new List<Side>()
    // {
    //   new Side("French Fries", "Crispy Idaho Potatos", 1.99f),
    //   new Side("Tater Tots", "Amazing golden little bits of heaven", 2.15f),
    //   new Side("Waffle fries", "Just like fries but more to 'em!", 1.99f)
    // };

  }


}

