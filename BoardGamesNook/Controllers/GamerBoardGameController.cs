﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerBoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGamerBoardGameService _gamerBoardGameService;
        private readonly IGamerService _gamerService;

        public GamerBoardGameController(IGamerBoardGameService gamerBoardGameService,
            IBoardGameService boardGameService,
            IGamerService gamerService)
        {
            _gamerBoardGameService = gamerBoardGameService;
            _boardGameService = boardGameService;
            _gamerService = gamerService;
        }

        public JsonResult Get(int id)
        {
            var gamerBoardGame = _gamerBoardGameService.Get(id);
            if (gamerBoardGame == null)
                return Json("Nie znaleziono gry dla gracza", JsonRequestBehavior.AllowGet);
            var gamerBoardGameViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModel(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gamerList = _gamerBoardGameService.GetAllByGamerNick(id);
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
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            // Tworzenie obiektu GamerBoardGame powinno być w osobnej metodzie.
            var gamerBoardGame = new GamerBoardGame
            {
                Id = _gamerBoardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamer.Id,
                Gamer = gamer,
                BoardGameId = boardGameId,
                BoardGame = _boardGameService.Get(boardGameId),
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
            _gamerBoardGameService.Add(gamerBoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(int gamerBoardGameId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var dbGamerBoardGame = _gamerBoardGameService.Get(gamerBoardGameId);
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
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            _gamerBoardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string id)
        {
            // Tutaj również jakaś logika biznesowa, która powinna być w serwisie.
            var gamer = _gamerService.GetByNick(id);
            var availableBoardGameList = _boardGameService.GetAll();
            var gamerBoardGameList = _gamerBoardGameService.GetAllByGamerNick(id);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();

            // Użycie AutoMappera
            var availableBoardGameListViewModel =
                BoardGameMapper.MapToGamerBoardGameViewModelList(gamerAvailableBoardGameList, gamer);

            return availableBoardGameListViewModel;
        }
    }
}