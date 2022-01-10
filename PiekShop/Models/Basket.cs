using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PiekShop.Models.Enums;

namespace PiekShop.Models;

public class Basket
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("IdentityUser")]
    public string UserId { get; set; }
    public virtual IdentityUser User { get; set; }
    public virtual List<BasketProducts> BasketProducts { get; set; }
    public StateOfTransaction StateOfTransaction { get; set; } = StateOfTransaction.Started;

    public decimal CalculateBasketCost => BasketProducts != null && BasketProducts.Count != 0?
        BasketProducts.Select(x=>x.Product.Price * x.Ammount).Sum() :
        0;
    
}