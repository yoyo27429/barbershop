using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Customer.Order
{
    public class addScoreModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public addScoreModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        [BindProperty]
        public Models.Review Review { get; set; }
        public int TempOrder = 1;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Review.OrderID = TempOrder;
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}