using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.Services.Models;
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
            var gameResultDto = _gameResultService.GetGameResult(id);

            var gameResultViewModel = Mapper.Map<GameResultViewModel>(gameResultDto);
            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameResultDtoList = _gameResultService.GetAllGameResults().ToList();

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultDtoList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(string.Format(Errors.GamerWithNicknameNotLoggedIn, nickname), JsonRequestBehavior.AllowGet);

            var gameResultDtoList = _gameResultService.GetAllByGamerNickname(nickname).ToList();

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultDtoList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int tableId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameResultList = _gameResultService.GetAllGameResultsByTableId(tableId);

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel gameResultViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!(Session["gamer"] is Gamer gamer))
                    return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

                var gameResultDto = Mapper.Map<GameResultDto>(gameResultViewModel);
                _gameResultService.AddGameResult(gameResultDto, gamer);

                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var errors = Helpers.GetErrorMessages(ModelState.Values);
            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMany(GameResultViewModel[] gameResultViewModels)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameResultDtoList = Mapper.Map<List<GameResultDto>>(gameResultViewModels);
            _gameResultService.AddGameResults(gameResultDtoList, gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(GameResultViewModel model)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gameResult = Mapper.Map<GameResult>(model);
            _gameResultService.EditGameResult(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameResultService.DeactivateGameResult(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private GameResult GetGameResultObj(GameResultViewModel gameResultViewModel, Gamer gamer)
        {
            var result = Mapper.Map<GameResult>(gameResultViewModel);
            result.Gamer = _gamerService.GetGamer(Guid.Parse(gameResultViewModel.GamerId));
            result.BoardGame = _boardGameService.Get(gameResultViewModel.BoardGameId);
            Mapper.Map(gamer, result);
            return result;
        }
    }
}