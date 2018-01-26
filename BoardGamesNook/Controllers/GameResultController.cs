﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.Controllers
{
    public class GameResultController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGameResultService _gameResultService;
        private readonly IGamerService _gamerService;

        public GameResultController(IGameResultService gameResultService, IBoardGameService boardGameService,
            IGamerService gamerService)
        {
            _gameResultService = gameResultService;
            _boardGameService = boardGameService;
            _gamerService = gamerService;
        }

        public JsonResult Get(int id)
        {
            var gameResult = _gameResultService.GetGameResult(id);
            if (gameResult == null)
                return Json(string.Format(Errors.BoardGameResultWithIdNotFound, id), JsonRequestBehavior.AllowGet);

            var gameResultViewModel = Mapper.Map<GameResultViewModel>(gameResult);

            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllGameResults().ToList();

            var gameResultListViewModel = Mapper.Map<List<GameResult>, List<GameResultViewModel>>(gameResultList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(string.Format(Errors.GamerWithNicknameNotLoggedIn, nickname), JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllByGamerNickname(nickname).ToList();

            var gameResultListViewModel = Mapper.Map<List<GameResult>, List<GameResultViewModel>>(gameResultList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int tableId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllGameResultsByTableId(tableId).ToList();

            var gameResultListViewModel = Mapper.Map<List<GameResultViewModel>>(gameResultList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel gameResultViewModel)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gameResult = GetGameResultObj(gameResultViewModel, gamer);
            _gameResultService.AddGameResult(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMany(GameResultViewModel[] gameResultViewModels)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            // Twój serwis (i repozytorium) powinien mieć metodę, która umożliwania dodanie wielu GameResult.
            foreach (var gameResultViewModel in gameResultViewModels)
            {
                var gameResult = GetGameResultObj(gameResultViewModel, gamer);
                _gameResultService.AddGameResult(gameResult);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(int gameResultId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var dbGameResult = _gameResultService.GetGameResult(gameResultId);
            if (dbGameResult != null)
                dbGameResult.ModifiedDate = DateTimeOffset.Now;
            else
                return Json(string.Format(Errors.BoardGameResultWithIdNotFound, gameResultId),
                    JsonRequestBehavior.AllowGet);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameResultService.DeleteGameResult(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        private GameResult GetGameResultObj(GameResultViewModel gameResultViewModel, Gamer gamer)
        {
            return new GameResult
            {
                Id = _gameResultService.GetAllGameResults().Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                GamerId = gameResultViewModel.GamerId,
                Gamer = _gamerService.GetGamer(gameResultViewModel.GamerId),
                BoardGameId = gameResultViewModel.BoardGameId,
                BoardGame = _boardGameService.Get(gameResultViewModel.BoardGameId),
                Points = gameResultViewModel.Points,
                Place = gameResultViewModel.Place,
                CreatedDate = DateTimeOffset.Now
            };
        }
    }
}