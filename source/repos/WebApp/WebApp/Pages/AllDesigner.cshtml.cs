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
    public class AllDesignerModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public AllDesignerModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Models.Employee> Employee { get; set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}