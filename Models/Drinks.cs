
namespace BurgerShack.Models
{
  public class Drink
  {
    public string Name { get; set; }

    public float Price { get; set; }


    public Drink(string name, float price)
    {
      Name = name;
      Price = price;
    }
  }

}