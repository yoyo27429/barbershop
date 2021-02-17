using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Admin.Notification
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public EditModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Notification Notification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification = await _context.Notifications
                .Include(n => n.Customer).FirstOrDefaultAsync(m => m.NotificationID == id);

            if (Notification == null)
            {
                return NotFound();
            }
           ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(Notification.NotificationID))
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

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationID == id);
        }
    }
}
