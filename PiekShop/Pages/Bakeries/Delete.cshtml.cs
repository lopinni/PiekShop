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
    public class DeleteModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public DeleteModel(PiekShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bakery = await _context.Bakery.FindAsync(id);

            if (Bakery != null)
            {
                _context.Bakery.Remove(Bakery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
