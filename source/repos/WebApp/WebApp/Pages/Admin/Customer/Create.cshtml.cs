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

namespace WebApp.Pages.Admin.Customer
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

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
        public Models.Customer Customer { get; set; }
        //set defult password
        public string Password = "Abc123?";

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //declare new user
            var user = new IdentityUser { UserName = Customer.Email, Email = Customer.Email };
            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                //find user_id in user table
                user = await _userManager.FindByEmailAsync(Customer.Email);
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
                Customer.UserID = Convert.ToString(user.Id);
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
            }
            

            return RedirectToPage("./Index");
        }
    }
}