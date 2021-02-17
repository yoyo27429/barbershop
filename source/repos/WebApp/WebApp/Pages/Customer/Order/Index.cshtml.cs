using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Customer.Order
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public IndexModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee).ToListAsync();
        }
    }
}
