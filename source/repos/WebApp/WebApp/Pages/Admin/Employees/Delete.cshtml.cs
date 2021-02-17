using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Pages.Admin.Employees
{
    public class DeleteModel : PageModel
    {
        //declare usermanager
        private readonly UserManager<IdentityUser> _userManager;
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DeleteModel(UserManager<IdentityUser> userManager, WebApp.Data.ApplicationDbContext context)
        {
            //assign usermanager
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Employee == null)
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

            Employee = await _context.Employees.FindAsync(id);
            var user = await _userManager.FindByIdAsync(Employee.UserID);

            if (Employee != null)
            {
                await _userManager.DeleteAsync(user);
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
