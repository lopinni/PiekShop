using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PiekShop.Models;

namespace PiekShop.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly PiekShop.Data.ApplicationDbContext _context;

        public GalleryModel(PiekShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bakery> Bakery { get; set; }

        public async Task OnGetAsync()
        {
            Bakery = await _context.Bakery.ToListAsync();
        }
    }
}
