﻿using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerBoardGameController : Controller
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor
        private GamerBoardGameService gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamerBoardGame = gamerBoardGameService.Get(id);
            if (gamerBoardGame == null)
            {
                // Komunikat błedu do resources
                return Json("Nie znaleziono gry dla gracza", JsonRequestBehavior.AllowGet);
            }
            var gamerBoardGameViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModel(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gamerList = gamerBoardGameService.GetAllByGamerNick(id);
            // Użycie AutoMappera
            var gamerListViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModelList(gamerList);

            return Json(gamerListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetGamerAvailableBoardGames(string id)
        {
            var gamerAvailableBoardGameListViewModel = GetGamerAvailableBoardGameList(id);
            return Json(gamerAvailableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int boardGameId)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            // Tworzenie obiektu GamerBoardGame powinno być w osobnej metodzie.
            GamerBoardGame gamerBoardGame = new GamerBoardGame()
            {
                Id = gamerBoardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamer.Id,
                Gamer = gamer,
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
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            GamerBoardGame dbGamerBoardGame = gamerBoardGameService.Get(gamerBoardGameId);
            if (dbGamerBoardGame != null)
            {
                // Controller nie powinien edytować obiektu, to powinno odbywać się w serwisie.
                dbGamerBoardGame.ModifiedDate = DateTimeOffset.Now;
                dbGamerBoardGame.Active = false;
            }
            else
            {
                // Komunikat błedu do resources
                return Json("Nie ma takiej gry dla gracza", JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            gamerBoardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string id)
        {
            // Tutaj również jakaś logika biznesowa, która powinna być w serwisie.
            Gamer gamer = gamerService.GetByNick(id);
            var availableBoardGameList = boardGameService.GetAll();
            var gamerBoardGameList = gamerBoardGameService.GetAllByGamerNick(id);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();

            // Użycie AutoMappera
            var availableBoardGameListViewModel = BoardGameMapper.MapToGamerBoardGameViewModelList(gamerAvailableBoardGameList, gamer);

            return availableBoardGameListViewModel;
        }
    }
}