using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerBoardGameController : Controller
    {
        private readonly BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());

        private readonly GamerBoardGameService gamerBoardGameService =
            new GamerBoardGameService(new GamerBoardGameRepository());

        private readonly GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamerBoardGame = gamerBoardGameService.Get(id);
            if (gamerBoardGame == null)
                return Json("Nie znaleziono gry dla gracza", JsonRequestBehavior.AllowGet);
            var gamerBoardGameViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModel(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gamerList = gamerBoardGameService.GetAllByGamerNick(id);
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
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var gamerBoardGame = new GamerBoardGame
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
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var dbGamerBoardGame = gamerBoardGameService.Get(gamerBoardGameId);
            if (dbGamerBoardGame != null)
            {
                dbGamerBoardGame.ModifiedDate = DateTimeOffset.Now;
                dbGamerBoardGame.Active = false;
            }
            else
            {
                return Json("Nie ma takiej gry dla gracza", JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            gamerBoardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string id)
        {
            var gamer = gamerService.GetByNick(id);
            var availableBoardGameList = boardGameService.GetAll();
            var gamerBoardGameList = gamerBoardGameService.GetAllByGamerNick(id);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();

            var availableBoardGameListViewModel =
                BoardGameMapper.MapToGamerBoardGameViewModelList(gamerAvailableBoardGameList, gamer);

            return availableBoardGameListViewModel;
        }
    }
}