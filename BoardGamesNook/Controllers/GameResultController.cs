using System;
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
        private readonly IGameTableService _gameTableService;

        public GameResultController(IGameResultService gameResultService, IBoardGameService boardGameService,
            IGamerService gamerService, IGameTableService gameTableService)
        {
            _gameResultService = gameResultService;
            _boardGameService = boardGameService;
            _gamerService = gamerService;
            _gameTableService = gameTableService;
        }

        public JsonResult Get(int id)
        {
            var gameResultDto = _gameResultService.GetGameResult(id);

            var gameResultViewModel = Mapper.Map<GameResultViewModel>(gameResultDto);
            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameResultDtoList = _gameResultService.GetAllGameResults().ToList();

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultDtoList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            var gameResultDtoList = _gameResultService.GetAllByGamerNickname(nickname).ToList();

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultDtoList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int tableId)
        {
            var gameResultList = _gameResultService.GetAllGameResultsByTableId(tableId);

            var gameResultListViewModel = Mapper.Map<IEnumerable<GameResultViewModel>>(gameResultList);

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel gameResultViewModel)
        {
            // AM: This business logic should be in the service.
            // WT: but what about VMs?
            // AM: Create additional models (Dto) - service should return this new model and here you should map this new model to view model
            var gameResult = GetGameResultObj(gameResultViewModel, Session["gamer"] as Gamer);
            _gameResultService.AddGameResult(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMany(GameResultViewModel[] gameResultViewModels)
        {
            // AM: This business logic should be in the service.
            // WT: but what about VMs?
            // AM: Create additional models (Dto) - service should return this new model and here you should map this new model to view model
            var gameResults = GetGameResultObjs(gameResultViewModels, Session["gamer"] as Gamer);
            _gameResultService.AddGameResults(gameResults);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(GameResultViewModel model)
        {
            var gameResult = Mapper.Map<GameResult>(model);
            _gameResultService.EditGameResult(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _gameResultService.DeactivateGameResult(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        private List<GameResult> GetGameResultObjs(IEnumerable<GameResultViewModel> gameResultViewModels, Gamer gamer)
        {
            var result = new List<GameResult>();
            foreach (var gameResultViewModel in gameResultViewModels)
            {
                var obj = GetGameResultObj(gameResultViewModel, gamer);
                result.Add(obj);
            }

            return result;
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