using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Pages.Admin.Employees
{
    public class CreateModel : PageModel
    {
        //declare usermanager
        private readonly UserManager<IdentityUser> _userManager;
        private readonly WebApp.Data.ApplicationDbContext _context;

        public CreateModel(UserManager<IdentityUser> userManager, WebApp.Data.ApplicationDbContext context)
            {
                //assign usermanager
                _userManager = userManager;
                _context = context;
            }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }
        //set defult password
        public string Password = "Abc123?";

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //declare new user
            var user = new IdentityUser { UserName = Employee.Email, Email = Employee.Email };
            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                //find user_id in user table
                user = await _userManager.FindByEmailAsync(Employee.Email);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            if (user != null)
            {
                //set userID in employee table
                Employee.UserID = Convert.ToString(user.Id);
                _context.Employees.Add(Employee);
                await _context.SaveChangesAsync();
            }
            

            return RedirectToPage("./Index");
        }
    }
}