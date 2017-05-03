using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.BoardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGameGeekIntegration.Models;

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
            int boardGameId = BoardGameGeekIntegration.BGGBoardGame.GetBoardGameId(name);
            if (boardGameId != 0)
            {
                BoardGame boardGame = BoardGameGeekIntegration.BGGBoardGame.GetBoardGameById(boardGameId);
                boardGame.Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<SimilarBoardGame> similarBoardGameList = BoardGameGeekIntegration.BGGBoardGame.GetSimilarBoardGameList(name);
                if (similarBoardGameList.Count > 0)
                {
                    //temporary - get only first 10 boardGames
                    return Json(similarBoardGameList.Take(10), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Nie znaleziono gry o nazwie " + name, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public JsonResult AddById(int id)
        {
            if (id != 0)
            {
                BoardGame boardGame = BoardGameGeekIntegration.BGGBoardGame.GetBoardGameById(id);
                boardGame.Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono gry o podanym Id " + id, JsonRequestBehavior.AllowGet);
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

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nie znaleziono gry o Id=" + boardGame.Id, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            boardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}