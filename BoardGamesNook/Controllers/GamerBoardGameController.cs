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
    public class GamerBoardGameController : Controller
    {
        GamerBoardGameService gamerBoardGameService = new GamerBoardGameService(new GamerBoardGameRepository());
        BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamerBoardGame = gamerBoardGameService.Get(id);
            var gamerBoardGameViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModel(gamerBoardGame);

            return Json(gamerBoardGameViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerId(int id)
        {
            var gamerList = gamerBoardGameService.GetAllByGamerId(id);
            var gamerListViewModel = GamerBoardGameMapper.MapToGamerBoardGameViewModelList(gamerList);

            return Json(gamerListViewModel, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetGamerAvailableBoardGames(int id)
        {
            var gamerAvailableBoardGameListViewModel = GetGamerAvailableBoardGameList(id);
            return Json(gamerAvailableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int gamerId, int boardGameId)
        {
            GamerBoardGame gamerBoardGame = new GamerBoardGame()
            {
                Id = gamerBoardGameService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamerId,
                Gamer = gamerService.Get(gamerId),
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
            GamerBoardGame dbGamerBoardGame= gamerBoardGameService.Get(gamerBoardGameId);
            if (dbGamerBoardGame!= null)
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

        private IEnumerable<GamerBoardGameViewModel> GetGamerAvailableBoardGameList(int gamerId)
        {
            Gamer gamer = gamerService.Get(gamerId);
            var availableBoardGameList = boardGameService.GetAll();
            var gamerBoardGameList = gamerBoardGameService.GetAllByGamerId(gamerId);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => !gamerBoardGameList.Any(y => y.BoardGameId == x.Id)).ToList();

            var availableBoardGameListViewModel = BoardGameMapper.MapToGamerBoardGameViewModelList(gamerAvailableBoardGameList, gamer);

            return availableBoardGameListViewModel;
        }
    }
}