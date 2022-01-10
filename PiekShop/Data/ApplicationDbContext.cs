using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PiekShop.Models;

namespace PiekShop.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketProducts> BasketProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {   
        builder.Entity<Basket>().HasOne(x => x.User).WithOne();
        builder.Entity<Basket>().HasMany(x => x.BasketProducts).WithOne(x => x.Basket);
        builder.Entity<Product>().HasMany(x => x.Baskets).WithOne(x => x.Product);
        builder.Entity<BasketProducts>().HasKey(x => new { x.BasketId, x.ProductId });
        base.OnModelCreating(builder);
    }
}