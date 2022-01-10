#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiekShop.Data;
using PiekShop.Models;
using PiekShop.Models.Enums;

namespace PiekShop.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BasketController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var applicationDbContext = _context.Baskets.Include(b => b.User);
            var activeBasket = await applicationDbContext.SingleOrDefaultAsync(x =>
                x.StateOfTransaction == StateOfTransaction.Started && x.UserId == currentUserId);
            if (activeBasket == null)
            {
                activeBasket = new Basket()
                {
                    UserId = currentUserId, 
                    StateOfTransaction = StateOfTransaction.Started,
                    BasketProducts = new List<BasketProducts>()
                };
                _context.Add(activeBasket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeBasket);
        }
    }
}
