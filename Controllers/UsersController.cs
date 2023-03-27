using Cv.Models;
using Cv.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using System.Web;

namespace Cv.Controllers
{
    public class UsersController : Controller
    {

        SignInManager<ApplicationUser> _signInManager;

        public UsersController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserName,Password,Email,ConfirmPassword,Agreed,Address,PhoneNumber")] ApplicationUser applicationUser)
        {
            ModelState.Remove("Orders");

            if (ModelState.IsValid)
            {
                _signInManager.UserManager.CreateAsync(applicationUser, applicationUser.Password).Wait();
                return Redirect("~/");
            }

            return View(applicationUser);

        }

        public IActionResult Login(string ReturnUrl = null, string error = null)
        {
            ViewData["returnUrl"] = ReturnUrl;
            ViewData["LoginFlag"] = error;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Login(string userName, string password, string? returnUrl, string? error)
        {
            Microsoft.AspNetCore.Identity.SignInResult identityResult;

            if (ModelState.IsValid)
            {
                var users = _signInManager.UserManager.FindByNameAsync(userName).Result;
                if (users != null && users.Deleted == true)
                {

                    Response.Redirect("/");
                }
                identityResult = _signInManager.PasswordSignInAsync(userName, password, false, false).Result;

                if (identityResult.Succeeded == true)
                {
                    if (_signInManager.UserManager.IsInRoleAsync(users, "Administrator").Result == true)
                    {
                        Response.Redirect("/Admin/Index");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            Response.Redirect(returnUrl);
                        }
                        else
                        {
                            Response.Redirect("/");
                        }
                    }
                    //return Redirect(Request.Headers["Referer"].ToString());
                }
                else
                {
                    string encodedUrl = HttpUtility.UrlEncode(returnUrl);

                    Response.Redirect("/Users/Login?error=Kullan%c4%b1c%c4%b1+Ad%c4%b1+veya+Parola+Hatal%c4%b1&ReturnUrl=" + encodedUrl);
                }
            }
            else
            {
                Response.Redirect("/Login");
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _signInManager.UserManager.Users == null)
            {
                return NotFound();
            }

            var Users = await _signInManager.UserManager.FindByIdAsync(id);
            if (Users == null)
            {
                return NotFound();
            }
            return View(Users);
        }
        //POST: Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_signInManager.UserManager.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pages'  is null.");
            }
            var Users = await _signInManager.UserManager.FindByIdAsync(id);
            if (Users != null)
            {
                Users.Deleted = true;
                await _signInManager.UserManager.UpdateAsync(Users);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var Users = await _signInManager.UserManager.FindByIdAsync(id);
            return View(Users);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,UserName,Password,Email,ConfirmPassword,Agreed,Address,PhoneNumber")] ApplicationUser applicationUser)
        {
            ModelState.Remove("Orders");

            var Users = await _signInManager.UserManager.FindByIdAsync(id);
            if (Users != null)
            {

                Users.Name = applicationUser.Name;
                Users.Address = applicationUser.Address;
                Users.UserName = applicationUser.UserName;
                Users.PhoneNumber = applicationUser.PhoneNumber;
                Users.PasswordHash = _signInManager.UserManager.PasswordHasher.HashPassword(applicationUser, applicationUser.Password);
                Users.Password = applicationUser.Password;
                Users.ConfirmPassword = applicationUser.ConfirmPassword;
                Users.Email = applicationUser.Email;
                await _signInManager.UserManager.UpdateAsync(Users);
            }


            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

    }

}