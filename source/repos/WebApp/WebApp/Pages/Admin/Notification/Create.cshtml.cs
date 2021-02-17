using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Admin.Notification
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public CreateModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID");
            return Page();
        }

        [BindProperty]
        public Models.Notification Notification { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notifications.Add(Notification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}