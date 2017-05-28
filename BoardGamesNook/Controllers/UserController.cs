using System.Web;
using System.Web.Mvc;
using BoardGamesNook.Services;
using Microsoft.AspNet.Identity;

namespace BoardGamesNook.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();

        public JsonResult GetUser()
        {
            User.Identity.GetUserId();
            var abc = System.Web.HttpContext.Current.Items["User"];
            //((HttpContext)HttpContext).Current.Items.Add("User", loggedUser);
            var loggedUser = userService.GetUser();
            return Json(loggedUser, JsonRequestBehavior.AllowGet);
        }
    }
}