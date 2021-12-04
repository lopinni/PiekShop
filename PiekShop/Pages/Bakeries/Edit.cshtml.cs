using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiekShop.Data;
using PiekShop.Models;

namespace PiekShop.Pages.Bakeries
{
    public class EditModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public EditModel(PiekShop.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bakery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BakeryExists(Bakery.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BakeryExists(int id)
        {
            return _context.Bakery.Any(e => e.ID == id);
        }
    }
}
