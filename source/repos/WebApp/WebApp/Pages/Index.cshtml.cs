using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public IndexModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Models.Service> Service { get; set; }
        public IList<Models.Employee> Employee { get; set; }
        public IList<Models.Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Services.ToListAsync();
            Employee = await _context.Employees.ToListAsync();
            Product = await _context.Products.ToListAsync();


        }
    }
}
