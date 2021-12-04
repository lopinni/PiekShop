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
    public class IndexModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public IndexModel(PiekShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bakery> Bakery { get;set; }

        public async Task OnGetAsync()
        {
            Bakery = await _context.Bakery.ToListAsync();
        }
    }
}
