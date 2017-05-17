using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;

namespace BoardGamesNook.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService(new UserRepository());

        public JsonResult Get(int id)
        {
            var user = userService.Get(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var userList = userService.GetAll();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string login, string password)
        {
            User user = new User()
            {
                Id = userService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                Login = login,
                Password = password,
                CreatedDate = DateTimeOffset.Now,
                IsConfirmed = true,
                Active = true
            };
            userService.Add(user);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
            User dbUser = userService.Get(user.Id);
            if (dbUser != null)
            {
                dbUser.Login = user.Login;
                dbUser.Password = user.Password;
                dbUser.ModifiedDate = DateTimeOffset.Now;
            }
            else
            {
                return Json("No user with Id=" + user.Id, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            userService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}