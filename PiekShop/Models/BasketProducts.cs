using System.ComponentModel.DataAnnotations;

namespace PiekShop.Models;

public class BasketProducts
{
    public int BasketId { get; set; }
    public virtual Basket Basket { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int Ammount { get; set; }
}