using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Pages
{
    public class DesignerModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DesignerModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Employee Employee { get; set; }
        public IList<Order> Order { get; set; }
        public IList<Review> Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);
            Order = await _context.Orders.Include(o => o.Review).Include(o => o.Customer).Where(o => o.EmployeeID == id).ToListAsync();

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}