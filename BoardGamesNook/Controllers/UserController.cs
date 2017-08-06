using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using Newtonsoft.Json;

namespace BoardGamesNook.Controllers
{
    public class UserController : Controller
    {
        public JsonResult Get()
        {
            var loggedUser = Session["user"];
            return Json(loggedUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Set(string userJson)
        {
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