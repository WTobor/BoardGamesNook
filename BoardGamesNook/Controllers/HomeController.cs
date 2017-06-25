using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Newtonsoft.Json;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        private GamerService gamerService = new GamerService(new GamerRepository());

        public ActionResult Index()
        {
            User loggedUser = (User)Session["user"];
            if (loggedUser != null)
            {
                Gamer gamer = gamerService.GetByEmail(loggedUser.Email);
                if (gamer != null)
                {
                    Session["gamer"] = gamer;
                }
            }
            return View();
        }
    }
}