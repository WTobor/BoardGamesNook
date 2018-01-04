using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        // W Global.asax widzę, że masz kontener DI - Autofac
        // W związku z tym powinnaś tego używać i wszystkie zależności przekazywać w konstruktorze
        // Dla tego przykładu konstruktor powinien wyglądać następująco:
        // public HomeController(GamerService gamerService)
        // {
        //     this.gamerService = gamerService;
        // }
        // private GamerService gamerService;
        //
        // Dodatkowo zmienne prywatne powinnaś dodawać z pokreślnikiem, czyli w tym przypadku:
        // private GamerService _gamerService;
        // Tak defaultowo podpowiada ReSharper - patrzysz na sugestię od niego? używasz operacji Cleanup Code (z reguły skrót Ctrl+E, Ctrl+C)?
        //
        // Dodatkowo skoro masz interface to ich używaj, tutaj zamiast private GamerService gamerService, powinno być:
        // private IGamerService gamerService
        //
        // Finalnie to powinno wyglądać tak:
        // public HomeController(IGamerService gamerService)
        // {
        //     _gamerService = gamerService;
        // }
        // private IGamerService _gamerService;
        //
        // Aby to działało, będziesz musiała dodać w Global.asax rejestrację tych typów.
        // Powinnaś to zrobić podobnie jak dla klasy CookieCache, czyli:
        // builder.RegisterType<GamerService>().As<IGamerService>();
        // Albo coś w tym stylu - na pewno jest tego mnóstwo na google.
        //
        // Uzycie DI powinno być we wszystkich klasach, czyli dla tego przypadku aby działało,
        // to jeszcze musisz zmienić klasę GamerService oraz zarejestrować GamerRepository

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
                var gamer = _gamerService.GetByEmail(loggedUser.Email);
                if (gamer != null)
                    Session["gamer"] = gamer;
            }
            return View();
        }
    }
}