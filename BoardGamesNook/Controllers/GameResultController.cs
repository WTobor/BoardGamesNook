using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
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
            var gameResult = _gameResultService.Get(id);
            if (gameResult == null)
                return Json("Nie znaleziono wyniku dla gracza", JsonRequestBehavior.AllowGet);
            // Użycie AutoMappera
            var gameResultViewModel =
                GameResultMapper.MapToGameResultViewModel(gameResult, _gamerService.Get(gameResult.CreatedGamerId));

            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAll();
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string nick)
        {
            var gamer = Session["gamer"] as Gamer;
            if (gamer == null)
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllByGamerNick(nick);
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int tableId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameResultList = _gameResultService.GetAllByTableId(tableId);
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList,
                _gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            // Tworzenie obietku gameResult powinno być w osobnej metodzie.
            // Dodatkowo zauważyłem, że czasemi używasz "var", a czasami konkretnego typu - można sobie ustawić w ReSharper jak powinno być.
            // Domyślnie używa się "var", bo jak się coś rekfaktoruje (np. zmienia typ zwracany przez metodę), to jest potem mniej do zmiany.
            // A sam typ powinien jednoznacznie wynikać z nazwy metody, np. w tym przypadku "GetGameResult".
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

            // Twój serwis (i repozytorium) powinien mieć metodę, która umożliwania dodanie wielu GameResult.
            // Dodatkowo masz powtórzenie (w tej i poprzedniej metodzie) kodu tworzącego GameResult.
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