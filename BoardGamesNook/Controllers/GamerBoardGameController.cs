using BoardGamesNook.Model;
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
        private GamerBoardGameService gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamerBoardGame = gamerBoardGameService.Get(id);
            var gamerBoardGameViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModel(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerId(string id = "")
        {
            if (!String.IsNullOrEmpty(id))
            {
                Gamer gamer = Session["gamer"] as Gamer;
                if (gamer == null)
                {
                    return Json("Nie znaleziono gracza", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    id = gamer.Id;
                }
            }
            var gamerList = gamerBoardGameService.GetAllByGamerId(id);
            var gamerListViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModelList(gamerList);

            return Json(gamerListViewModel, JsonRequestBehavior.AllowGet);
        }

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
                return Json("Nie znaleziono gracza", JsonRequestBehavior.AllowGet);
            }

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
            GamerBoardGame dbGamerBoardGame = gamerBoardGameService.Get(gamerBoardGameId);
            if (dbGamerBoardGame != null)
            {
                dbGamerBoardGame.ModifiedDate = DateTimeOffset.Now;
                dbGamerBoardGame.Active = false;
            }
            else
            {
                return Json("No GamerBoardGame with Id=" + gamerBoardGameId, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gamerBoardGameService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(string gamerId)
        {
            Gamer gamer = gamerService.Get(gamerId);
            var availableBoardGameList = boardGameService.GetAll();
            var gamerBoardGameList = gamerBoardGameService.GetAllByGamerId(gamerId);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();

            var availableBoardGameListViewModel = BoardGameMapper.MapToGamerBoardGameViewModelList(gamerAvailableBoardGameList, gamer);

            return availableBoardGameListViewModel;
        }
    }
}