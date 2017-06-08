using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using Newtonsoft.Json;

namespace BoardGamesNook.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();

        public JsonResult GetUser()
        {
            var loggedUser = Session["user"];
            return Json(loggedUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetUser(string userJson)
        {
            var user = JsonConvert.DeserializeObject<User>(userJson);
            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }

        public JsonResult LogOutUser()
        {
            Session["user"] = null;
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}