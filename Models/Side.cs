
using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side
  {
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public float Price { get; set; }

    public Side(string name, string description, float price)
    {
      Name = name;
      Description = description;
      Price = price;
    }

  }
}