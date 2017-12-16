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
        private readonly BoardGameService _boardGameService = new BoardGameService(new BoardGameRepository());
        private readonly GameResultService _gameResultService = new GameResultService(new GameResultRepository());
        private readonly GamerService _gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gameResult = _gameResultService.Get(id);
            if (gameResult == null)
                return Json("Nie znaleziono wyniku dla gracza", JsonRequestBehavior.AllowGet);
            var gameResultViewModel =
                GameResultMapper.MapToGameResultViewModel(gameResult, _gamerService.Get(gameResult.CreatedGamerId));

            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAll().ToList();
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllByGamerNick(id).ToList();
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllByTableId(id).ToList();
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var gameResult = new GameResult
            {
                Id = _gameResultService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                GamerId = model.GamerId,
                Gamer = _gamerService.Get(model.GamerId),
                BoardGameId = model.BoardGameId,
                BoardGame = _boardGameService.Get(model.BoardGameId),
                Points = model.Points,
                Place = model.Place,
                CreatedDate = DateTimeOffset.Now
            };
            _gameResultService.Add(gameResult);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMany(GameResultViewModel[] model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            foreach (var gameResultViewModel in model)
            {
                var gameResult = new GameResult
                {
                    Id = _gameResultService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                    CreatedGamerId = gamer.Id,
                    GamerId = gameResultViewModel.GamerId,
                    Gamer = _gamerService.Get(gameResultViewModel.GamerId),
                    BoardGameId = gameResultViewModel.BoardGameId,
                    BoardGame = _boardGameService.Get(gameResultViewModel.BoardGameId),
                    Points = gameResultViewModel.Points,
                    Place = gameResultViewModel.Place,
                    CreatedDate = DateTimeOffset.Now
                };
                _gameResultService.Add(gameResult);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(int gameResultId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var dbGameResult = _gameResultService.Get(gameResultId);
            if (dbGameResult != null)
                dbGameResult.ModifiedDate = DateTimeOffset.Now;
            else
                return Json("Nie ma takiego wyniku dla gracza", JsonRequestBehavior.AllowGet);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            _gameResultService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}