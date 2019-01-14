using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Description { get; set; }
    [Range(5, float.MaxValue)]
    public float Price { get; set; }

    public Burger(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}