using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGamesNook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int boardGameId = BoardGameGeekIntegration.BGGBoardGame.GetBoardGameId("Terra Mystica");
            if (boardGameId != 0)
            {
                //int boardGameId = 120677;
                BoardGameGeekIntegration.BGGBoardGame.GetBoardGameById(boardGameId);
            }

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