#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiekShop.Data;
using PiekShop.Models;
using PiekShop.Models.Enums;

namespace PiekShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Where(x => x.IsActive).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id && m.IsActive);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int amount)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var activeBasket = await _context.Baskets.SingleOrDefaultAsync(x =>
                x.StateOfTransaction == StateOfTransaction.Started && x.UserId == currentUserId);

            var basketProduct = await
                _context.BasketProducts.SingleOrDefaultAsync(x => x.BasketId == activeBasket.Id && x.ProductId == productId);

            if (basketProduct != null)
            {
                basketProduct.Amount += amount;
            }
            else
            {
                var productInBasket = new BasketProducts()
                    { Amount = amount, BasketId = activeBasket.Id, ProductId = productId };
                _context.Add(productInBasket);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
