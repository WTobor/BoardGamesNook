﻿using BoardGamesNook.Model;
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
    [AuthorizeCustom]
    public class BoardGameController : Controller
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());

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
            // Tutaj również jakaś logika biznesowa, która powinna być w serwisie.
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
                    // Komunikat błedu do resources
                    return Json("Nie znaleziono gry o nazwie " + name, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public JsonResult AddById(int id)
        {
            // Tutaj również jakaś logika biznesowa, która powinna być w serwisie.
            if (id != 0)
            {
                BoardGame boardGame = BoardGameGeekIntegration.BGGBoardGame.GetBoardGameById(id);
                boardGame.Id = boardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            // Komunikat błedu do resources
            return Json("Nie znaleziono gry o podanym Id " + id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGameViewModel boardGame)
        {
            BoardGame dbBoardGame = boardGameService.Get(boardGame.Id);
            // Controller nie powinien edytować obiektu, to powinno odbywać się w serwisie.
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
                // Komunikat błedu do resources
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