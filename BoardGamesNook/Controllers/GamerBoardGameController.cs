using System.Collections.Generic;
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
        private readonly IGamerBoardGameService _gamerBoardGameService;
        private readonly IGamerService _gamerService;

        public GamerBoardGameController(IGamerBoardGameService gamerBoardGameService,
            IGamerService gamerService)
        {
            _gamerBoardGameService = gamerBoardGameService;
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
            _gamerBoardGameService.Add(boardGameId, Session["gamer"] as Gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(int gamerBoardGameId)
        {
            _gamerBoardGameService.EditGamerBoardGame(gamerBoardGameId);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _gamerBoardGameService.DeactivateGamerBoardGame(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string nickname)
        {
            // AM: This business logic should be in the service.
            // WT: I have VMs here, I cannot move it to service
            // AM: You have VMs later - first two lines should be replad with one line - controller should have dependency only to one service.
            var gamer = _gamerService.GetGamerBoardGameByNickname(nickname);
            var gamerAvailableBoardGameList = _gamerBoardGameService.GetGamerAvailableBoardGameList(nickname);

            var availableBoardGameListViewModel =
                Mapper.Map<List<GamerBoardGameViewModel>>(gamerAvailableBoardGameList);
            foreach (var obj in availableBoardGameListViewModel)
                Mapper.Map(gamer, obj);

            return availableBoardGameListViewModel;
        }
    }
}