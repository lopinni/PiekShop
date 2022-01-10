using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiekShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //Only support one type of currency so good practice there would be an creating an money/currency object :)
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual List<BasketProducts> Baskets { get; set; } = new List<BasketProducts>();
}