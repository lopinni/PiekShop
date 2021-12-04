using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PiekShop.Data;
using PiekShop.Models;

namespace PiekShop.Pages.Bakeries
{
    public class CreateModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public CreateModel(PiekShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bakery Bakery { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bakery.Add(Bakery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
