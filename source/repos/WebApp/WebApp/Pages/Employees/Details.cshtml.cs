﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
