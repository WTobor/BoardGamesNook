﻿using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using Newtonsoft.Json;

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
        // Tak defaultowo podpowiada ReSharper (używasz operacji Cleanup-Code?)
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
        // Powinnaś to zrobić podobnie jak dla clasy CookieCache, czyli:
        // builder.RegisterType<GamerService>().As<IGamerService>();
        // Albo coś w tym stylu - na pewno jest tego mnóstwo na google.
        //
        // Uzycie DI powinno być we wszystkich klasa, czyli dla tego przypadku aby działało,
        // to jeszcze musisz zmienić klasę GamerService oraz zarejestrować GamerRepository

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