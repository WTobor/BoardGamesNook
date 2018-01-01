using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services; // ten namespace nie jest nigdzie używany
using Newtonsoft.Json;

namespace BoardGamesNook.Controllers
{
    public class UserController : Controller
    {
        // Nic do dodania, wydaje się ok.
        public JsonResult Get()
        {
            var loggedUser = Session["user"];
            return Json(loggedUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Set(string userJson)
        {
            // Jak dasz "User" zamiast "string" w parametrze, to on sam przypadkiem nie zrobi deserializacji?
            var user = JsonConvert.DeserializeObject<User>(userJson);
            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }

        public JsonResult LogOut()
        {
            Session["user"] = null;
            Session["gamer"] = null;
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}