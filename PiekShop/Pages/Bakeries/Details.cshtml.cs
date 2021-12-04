using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PiekShop.Data;
using PiekShop.Models;

namespace PiekShop.Pages.Bakeries
{
    public class DetailsModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public DetailsModel(PiekShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Bakery Bakery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bakery = await _context.Bakery.FirstOrDefaultAsync(m => m.ID == id);

            if (Bakery == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
