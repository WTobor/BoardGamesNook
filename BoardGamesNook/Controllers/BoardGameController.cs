using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.Repository;

namespace BoardGamesNook.Controllers
{
    public class BoardGameController :Controller
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
        public JsonResult Add(string name, string description, int minPlayers, int maxPlayers, TimeSpan minTime, TimeSpan maxTime, int minAge)
        {
            BoardGame BoardGame = new BoardGame()
            {
                Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                Name = name,
                Description = description,
                MinPlayers = minPlayers,
                MaxPlayers = maxPlayers,
                MinTime = minTime,
                MaxTime = maxTime,
                CreatedDate = DateTimeOffset.Now,
                Active = true,
                IsConfirmed = true
            };

            boardGameService.Add(BoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGame boardGame)
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

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            boardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}