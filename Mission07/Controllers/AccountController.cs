using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mission07.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Controllers
{
    public class AccountController : Controller
    {
        // bring in ability to sign in with aspnetcore.identity
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        // initialize the variables
        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }

        // get method for page when form is called
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        // post method for page when form is submitted
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            // method checks to see if login credentials are valid
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Username);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        // if valid, redirect to admin page
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                    }
                }
            }

            // if invalid throw error and redirect back to login page with password empty
            ModelState.AddModelError("", "Incorrect username and/or password");
            return View(loginModel);

        }

        // not required but I chose to include a method to logout
        public async Task<RedirectResult> Logout (string returnUrl = "/")
        {
            await signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }

    }
}
