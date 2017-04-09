using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.Repository;
using BoardGamesNook.ViewModels.BoardGame;

namespace BoardGamesNook.Controllers
{
    public class BoardGameController : Controller
    {
        BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());

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
            BoardGame boardGame = new BoardGame()
            {
                Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                Name = name,
                Description = "",
                MinPlayers = 1,
                MaxPlayers = 1,
                MinTime = new TimeSpan(),
                MaxTime = new TimeSpan(),
                CreatedDate = DateTimeOffset.Now,
                Active = true,
                IsConfirmed = true
            };

            boardGameService.Add(boardGame);

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGameViewModel boardGame)
        {
            BoardGame dbBoardGame = boardGameService.Get(boardGame.Id);
            if (dbBoardGame != null)
            {
                dbBoardGame.Name = boardGame.Name;
                dbBoardGame.Description = boardGame.Description;
                dbBoardGame.MinPlayers = boardGame.MinPlayers;
                dbBoardGame.MaxPlayers = boardGame.MaxPlayers;
                dbBoardGame.MinTime = boardGame.MinTime;
                dbBoardGame.MaxTime = boardGame.MaxTime;
                dbBoardGame.ModifiedDate = DateTimeOffset.Now;
            }
            else
            {
                return Json("No BoardGame with Id=" + boardGame.Id, JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            boardGameService.Delete(id);

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}