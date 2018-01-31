using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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
            var gamerBoardGame = _gamerBoardGameService.GetGamerBoardGame(id);
            if (gamerBoardGame == null)
                return Json(string.Format(Errors.GamerBoardGameWithIdNotFound, id), JsonRequestBehavior.AllowGet);
            var gamerBoardGameViewModel = Mapper.Map<GamerBoardGameViewModel>(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(string.Format(Errors.GamerWithNicknameNotLoggedIn, nickname), JsonRequestBehavior.AllowGet);
            var gamerList = _gamerBoardGameService.GetAllGamerBoardGamesByGamerNickname(nickname);
            var gamerListViewModel = Mapper.Map<IEnumerable<GamerBoardGameViewModel>>(gamerList);

            return Json(gamerListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetGamerAvailableBoardGames(string nickname)
        {
            var gamerAvailableBoardGameListViewModel = GetGamerAvailableBoardGameList(nickname);
            return Json(gamerAvailableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int boardGameId)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gamerBoardGame = GetGamerBoardGameObj(boardGameId, gamer);
            _gamerBoardGameService.Add(gamerBoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(int gamerBoardGameId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var dbGamerBoardGame = _gamerBoardGameService.GetGamerBoardGame(gamerBoardGameId);

            if (dbGamerBoardGame == null)
                return Json(string.Format(Errors.GamerBoardGameWithIdNotFound, gamerBoardGameId),
                    JsonRequestBehavior.AllowGet);
            _gamerBoardGameService.EditGamerBoardGame(dbGamerBoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gamerBoardGameService.DeactivateGamerBoardGame(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string nickname)
        {
            var gamer = _gamerService.GetGamerBoardGameByNickname(nickname);
            var gamerAvailableBoardGameList = _gamerBoardGameService.GetGamerAvailableBoardGameList(nickname);

            var availableBoardGameListViewModel =
                Mapper.Map<List<GamerBoardGameViewModel>>(gamerAvailableBoardGameList);
            foreach (var obj in availableBoardGameListViewModel)
                Mapper.Map(gamer, obj);

            return availableBoardGameListViewModel;
        }


        private GamerBoardGame GetGamerBoardGameObj(int boardGameId, Gamer gamer)
        {
            return new GamerBoardGame
            {
                Id = _gamerBoardGameService.GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamer.Id,
                Gamer = gamer,
                BoardGameId = boardGameId,
                BoardGame = _boardGameService.Get(boardGameId),
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
        }
    }
}