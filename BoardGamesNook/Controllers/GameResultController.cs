using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.Controllers
{
    public class GameResultController : Controller
    {
        private GameResultService gameResultService = new GameResultService(new GameResultRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gameResult = gameResultService.Get(id);
            if (gameResult == null)
            {
                return Json("Nie znaleziono wyniku dla gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultViewModel = GameResultMapper.MapToGameResultViewModel(gameResult, gamerService.Get(gameResult.CreatedGamerId));

            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAll();
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAllByGamerNick(id);
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAllByTableId(id);
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel model)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            GameResult gameResult = new GameResult()
            {
                Id = gameResultService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                GamerId = model.GamerId,
                Gamer = gamerService.Get(model.GamerId),
                BoardGameId = model.BoardGameId,
                BoardGame = boardGameService.Get(model.BoardGameId),
                Points = model.Points,
                Place = model.Place,
                CreatedDate = DateTimeOffset.Now
            };
            gameResultService.Add(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMany(GameResultViewModel[] model)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            foreach (var gameResultViewModel in model)
            {
                GameResult gameResult = new GameResult()
                {
                    Id = gameResultService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                    CreatedGamerId = gamer.Id,
                    GamerId = gameResultViewModel.GamerId,
                    Gamer = gamerService.Get(gameResultViewModel.GamerId),
                    BoardGameId = gameResultViewModel.BoardGameId,
                    BoardGame = boardGameService.Get(gameResultViewModel.BoardGameId),
                    Points = gameResultViewModel.Points,
                    Place = gameResultViewModel.Place,
                    CreatedDate = DateTimeOffset.Now
                };
                gameResultService.Add(gameResult);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(int gameResultId)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            GameResult dbGameResult = gameResultService.Get(gameResultId);
            if (dbGameResult != null)
            {
                dbGameResult.ModifiedDate = DateTimeOffset.Now;
            }
            else
            {
                return Json("Nie ma takiego wyniku dla gracza", JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            gameResultService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}