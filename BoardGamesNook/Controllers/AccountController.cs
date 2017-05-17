using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.Model;

namespace BoardGamesNook.Controllers
{
    public class AccountController : Controller
    {
        AccountService accountService = new AccountService(new AccountRepository());
        UserService userService = new UserService(new UserRepository());

        public JsonResult Login(string login, string password)
        {
            var boardGame = accountService.Login(login, password);
            return Json(boardGame, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Register(string login, string password)
        {
            bool registrationSuccess = false;
            bool loginAllowed = accountService.IsLoginAllowed(login);
            if (loginAllowed)
            {
                int newId = userService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                User user = new User()
                {
                    Id = newId,
                    Login = login,
                    Password = password,
                    CreatedDate = DateTimeOffset.Now,
                    IsConfirmed = true,
                    Active = true
                };
                userService.Add(user);
                User newUser = userService.Get(newId);
                if (newUser != null)
                {
                    registrationSuccess = true;
                }
            }

            return Json(registrationSuccess, JsonRequestBehavior.AllowGet);
        }
    }
}