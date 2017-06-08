using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}