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
        // Tutaj również wstrzykiaanie zależności przez konstruktor
        private GameResultService gameResultService = new GameResultService(new GameResultRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gameResult = gameResultService.Get(id);
            if (gameResult == null)
            {
                // Komunikat błedu do resources
                return Json("Nie znaleziono wyniku dla gracza", JsonRequestBehavior.AllowGet);
            }
            // Użycie AutoMappera
            var gameResultViewModel = GameResultMapper.MapToGameResultViewModel(gameResult, gamerService.Get(gameResult.CreatedGamerId));

            return Json(gameResultViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAll();
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        // Jeśli pobierasz po "nick" (nie wiem czy jest w ogóle takie słowo w języku angielskim, chyba powinno być "nickname") to czemu parametr nazywa się "id"?
        public JsonResult GetAllByGamerNick(string id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAllByGamerNick(id);
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        // Tutaj parametr powinien nazywać się "tableId", bo samo "id" to nie wiadomo o jakie id chodzi
        public JsonResult GetAllByTableId(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameResultList = gameResultService.GetAllByTableId(id);
            // Użycie AutoMappera
            // GameResult ma w sobie Gamera, to dlaczego go pobierasz dodatkowo osobno?
            var gameResultListViewModel = GameResultMapper.MapToGameResultViewModelList(gameResultList, gamerService.Get(gameResultList.Select(x => x.GamerId).FirstOrDefault()));

            return Json(gameResultListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameResultViewModel model)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            // Tworzenie obietku gameResult powinno być w osobnej metodzie.
            // Dodatkowo zauważyłem, że czasemi używasz "var", a czasami konkretnego typu - można sobie ustawić w ReSharper jak powinno być.
            // Domyślnie używa się "var", bo jak się coś rekfaktoruje (np. zmienia typ zwracany przez metodę), to jest potem mniej do zmiany.
            // A sam typ powinien jednoznacznie wynikać z nazwy metody, np. w tym przypadku "GetGameResult".
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
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            // Twój serwis (i repozytorium) powinien mieć metodę, która umożliwania dodanie wielu GameResult.
            // Dodatkowo masz powtórzenie (w tej i poprzedniej metodzie) kodu tworzącego GameResult.
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
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            GameResult dbGameResult = gameResultService.Get(gameResultId);
            if (dbGameResult != null)
            {
                // Kontroler nie powinien zmieniać obiektu, takie rzeczy powinny odbywać się w serwisie.
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
                // Komunikat błedu do resources
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            gameResultService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}