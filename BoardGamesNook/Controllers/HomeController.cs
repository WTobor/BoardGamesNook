using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamerService _gamerService;

        public HomeController(IGamerService gamerService)
        {
            _gamerService = gamerService;
        }

        public ActionResult Index()
        {
            var loggedUser = (User) Session["user"];
            if (loggedUser != null)
            {
                var gamer = _gamerService.GetGamerByEmail(loggedUser.Email);
                // Is this statement needed? Probably in this context Session["gamer"] is always null, so it shouldn't be a problem to assign null to it.
                if (gamer != null)
                    Session["gamer"] = gamer;
            }

            return View();
        }
    }
}