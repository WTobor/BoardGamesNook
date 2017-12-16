using System;
using System.Linq;
using System.Web.Mvc;
using BoardGameGeekIntegration;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.BoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class BoardGameController : Controller
    {
        private readonly BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());

        public JsonResult Get(int id)
        {
            var boardGame = boardGameService.Get(id);
            return Json(boardGame, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var boardGameList = boardGameService.GetAll();
            return Json(boardGameList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            var boardGameId = BGGBoardGame.GetBoardGameId(name);
            if (boardGameId != 0)
            {
                var boardGame = BGGBoardGame.GetBoardGameById(boardGameId);
                boardGame.Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var similarBoardGameList = BGGBoardGame.GetSimilarBoardGameList(name);
            if (similarBoardGameList.Count > 0)
                return Json(similarBoardGameList.Take(10), JsonRequestBehavior.AllowGet);
            return Json("Nie znaleziono gry o nazwie " + name, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddById(int id)
        {
            if (id != 0)
            {
                var boardGame = BGGBoardGame.GetBoardGameById(id);
                boardGame.Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono gry o podanym Id " + id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGameViewModel boardGame)
        {
            var dbBoardGame = boardGameService.Get(boardGame.Id);
            if (dbBoardGame != null)
            {
                dbBoardGame.Name = boardGame.Name;
                dbBoardGame.Description = boardGame.Description;
                dbBoardGame.MinPlayers = boardGame.MinPlayers;
                dbBoardGame.MaxPlayers = boardGame.MaxPlayers;
                dbBoardGame.MinTime = boardGame.MinTime;
                dbBoardGame.MaxTime = boardGame.MaxTime;
                dbBoardGame.ModifiedDate = DateTimeOffset.Now;

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono gry o Id=" + boardGame.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            boardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}