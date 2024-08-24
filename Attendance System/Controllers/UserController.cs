using Attendance_System.Interfaces;
using Attendance_System.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Attendance_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser user;
        public UserController(IUser _user)
        {
            user = _user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var Authenticated = user.Login(login.UserName, login.Password);
            var User = user.GetByName(login.UserName);

            if (Authenticated)
            {
                Claim C1 = new Claim(ClaimTypes.Name, login.UserName);
                Claim C2 = new Claim(ClaimTypes.Email, User.Email);
                Claim C3 = new Claim(ClaimTypes.Role, User.Role);

                ClaimsIdentity CI = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                CI.AddClaim(C1);
                CI.AddClaim(C2);
                CI.AddClaim(C3);

                ClaimsPrincipal CP = new ClaimsPrincipal(CI);

                await HttpContext.SignInAsync(CP);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password is Incorrect");
                return View(login);
                // user does not exist
            }
        }

        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterStudent(RegisterModel model)
        {
            user.RegisterStudent(model);
            return View();
        }

        public IActionResult RegisterHR()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterHR(RegisterModel model)
        {
            user.RegisterHR(model);
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
