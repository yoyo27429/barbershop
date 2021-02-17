using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Admin.Product
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
