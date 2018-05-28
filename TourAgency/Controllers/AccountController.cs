using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using TourAgency.Models;
using BLL.DTO;
using System.Security.Claims;
using BLL.Interfaces;
using BLL.Infrastructure;

namespace TourAgency.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    TempData["successful"] = string.Format("Добро пожаловать");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                {
                    TempData["successful"] = string.Format("Вас успешно зарегистрировано");
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        public async Task SetInitialDataAsync()
        {
            //await UserService.SetInitialData(new UserDTO
            //{
            //    Email = "admin@mail.ru",
            //    UserName = "admin@mail.ru",
            //    Password = "admin",
            //    Name = "Семен Семенович Горбунков",
            //    Role = "admin",
            //}, new List<string> { "user", "admin" });

            await UserService.SetInitialData(new UserDTO
            {
                Email = "manager@gmail.com",
                UserName = "manager@gmail.com",
                Password = "manager",
                Name = "Василий Васильевич Каракаев",
                Role = "manager",
            }, new List<string> { "user", "manager" });
        }
    }
}
