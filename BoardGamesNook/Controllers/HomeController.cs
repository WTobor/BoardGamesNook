using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        private readonly GamerService _gamerService = new GamerService(new GamerRepository());

        public ActionResult Index()
        {
            var loggedUser = (User) Session["user"];
            if (loggedUser != null)
            {
                var gamer = _gamerService.GetByEmail(loggedUser.Email);
                if (gamer != null)
                    Session["gamer"] = gamer;
            }
            return View();
        }
    }
}