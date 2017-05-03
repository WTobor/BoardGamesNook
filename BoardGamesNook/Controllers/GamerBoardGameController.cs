using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BoardGamesNook.Controllers
{
    public class GamerBoardGameController : Controller
    {
        GamerBoardGameService gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
        BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamerBoardGame = gamerBoardGameService.Get(id);
            return Json(gamerBoardGame, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = gamerBoardGameService.GetAll();
            return Json(gamerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int gamerId, int BGGId)
        {
            int boardGameId = boardGameService.GetAll().Where(x => x.BGGId == BGGId).Select(x => x.Id).FirstOrDefault();
            GamerBoardGame gamerBoardGame = new GamerBoardGame()
            {
                Id = gamerBoardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamerId,
                Gamer = gamerService.Get(gamerId),
                BoardGameId = boardGameId,
                BoardGame = boardGameService.Get(boardGameId),
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
            gamerBoardGameService.Add(gamerBoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(int gamerBoardGameId) 
        {
            GamerBoardGame dbGamerBoardGame= gamerBoardGameService.Get(gamerBoardGameId);
            if (dbGamerBoardGame!= null)
            {
                dbGamerBoardGame.ModifiedDate = DateTimeOffset.Now;
                dbGamerBoardGame.Active = false;
            }
            else
            {
                return Json("No GamerBoardGame with Id=" + gamerBoardGameId, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gamerBoardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}