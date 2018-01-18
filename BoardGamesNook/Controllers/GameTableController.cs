using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameTableController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGameParticipationService _gameParticipationService;
        private readonly IGameTableService _gameTableService;

        public GameTableController(IGameTableService gameTableService, IBoardGameService boardGameService,
            IGameParticipationService gameParticipationService)
        {
            _gameTableService = gameTableService;
            _boardGameService = boardGameService;
            _gameParticipationService = gameParticipationService;
        }

        public JsonResult Get(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameTable = new GameTable
            {
                CreatedGamer = gamer,
                CreatedGamerId = gamer.Id
            };
            if (id > 0)
                gameTable = _gameTableService.GetGameTable(id);
            var gameTableViewModel = Mapper.Map<List<TableBoardGameViewModel>>(gameTable);

            return Json(gameTableViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            // 
            // Ponadto cały ten kod poniżej (te 7 albo 8 linijek, bez mappera) wygląda mi na jakąś logikę biznesową,
            // więc powinno to wszystko być w serwisie.
            // W tym przypadku metoda GetGameTable, mogłaby przyjmować jeszcze obiekt gamer,
            // albo metoda GetAvailableTableBoardGameList przyjmowałaby nickname gameTableViewModel i gamer - nie znam dokładnie biznesu tutaj,
            // więc na szybko nie powiem co lepsze.
            var gameTable = _gameTableService.GetGameTable(id) ?? new GameTable
            {
                CreatedGamer = gamer,
                CreatedGamerId = gamer.Id
            };
            var availableTableBoardGameList = _gameTableService.GetAvailableTableBoardGameList(gameTable).ToList();
            var availableTableBoardGameListViewModel =
               Mapper.Map<List<BoardGame>, List<TableBoardGameViewModel>>(availableTableBoardGameList);
            availableTableBoardGameListViewModel.ForEach(x =>
            {
                x.GamerId = gamer.Id;
                x.GamerNickname = gamer.Nickname;
            });

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = _gameTableService.GetAllGameTables();
            var gameTableListViewModel = Mapper.Map<List<TableBoardGameViewModel>>(gameTableList);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            var gameTableList = _gameTableService.GetAllGameTablesByGamerNickname(nickname);
            var gameTableListViewModel = Mapper.Map<List<TableBoardGameViewModel>>(gameTableList);
            //double mapper
            gameTableListViewModel.ForEach(x => x.GamerNickname = nickname);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameTable = GetGameTableObj(model, gamer);
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            gameTable.BoardGames = new List<BoardGame>();
            foreach (var boardGameId in tableBoardGameIdList)
            {
                var boardGame = _boardGameService.Get(boardGameId);
                if (boardGame != null)
                    gameTable.BoardGames.Add(boardGame);
                else
                    return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId,
                        JsonRequestBehavior.AllowGet);
            }
            // Nie wiem czy tutaj nie lepiej byłoby metodę nazwać Create.
            // AddGameTable jest dobre do repozytorium, ale w servisie to nie wygląda na jednoznaczną metodę.
            _gameTableService.AddGameTable(gameTable);
            // Widzę, że w kodzie powyżej masz wołaną metodę "AddGameTable" z dwóch serwisów.
            // Ponownie wygląda mi to na jaąś logikę biznesową, która powinna być w serwisie,
            // a nie kontrolerze. Wydaje mi się, że cały kod od linijki 104 do 132 powinien być zawarty w moedzie AddGameTable w gameTableService.

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private GameTable GetGameTableObj(GameTableViewModel gameTableViewModel, Gamer gamer)
        {
            return new GameTable
            {
                Name = gameTableViewModel.Name,
                City = gameTableViewModel.City,
                Street = gameTableViewModel.Street,
                IsPrivate = gameTableViewModel.IsPrivate,
                MinPlayersNumber = gameTableViewModel.MinPlayers,
                MaxPlayersNumber = gameTableViewModel.MaxPlayers,
                IsFull = false,
                Id = _gameTableService.GetAllGameTablesByGamerNickname(gamer.Nickname).Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                CreatedGamer = gamer,
                CreatedDate = DateTimeOffset.Now
            };
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTableViewModel)
        {
            // Dwie rzeczy:
            // po pierwsze do tych przypisać użyć mappera, albo przenieść je do osobnej metody
            // po drugie - ponownie to jakaś logika biznesowa i powinna być zapewne w metodzie
            // EditGameTable klasy gameTableService.
            var dbGameTable =
                _gameTableService.GetGameTable(gameTableViewModel
                    .Id); // ten obiekt powinien nazywać się gameTableViewModel, a ten z metody gameTableVM albo po prostu gameTableViewModel

            if (dbGameTable != null)
            {
                dbGameTable.City = gameTableViewModel.City;
                dbGameTable.Street = gameTableViewModel.Street;
                dbGameTable.IsPrivate = gameTableViewModel.IsPrivate;
                dbGameTable.MinPlayersNumber = gameTableViewModel.MinPlayers;
                dbGameTable.MaxPlayersNumber = gameTableViewModel.MaxPlayers;
                var tableBoardGameIdList = gameTableViewModel.TableBoardGameList.Select(x => x.BoardGameId).ToList();

                dbGameTable.BoardGames = new List<BoardGame>();
                foreach (var boardGameId in tableBoardGameIdList)
                {
                    var boardGame = _boardGameService.Get(boardGameId);
                    if (boardGame != null)
                        dbGameTable.BoardGames.Add(boardGame);
                    else
                        return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId,
                            JsonRequestBehavior.AllowGet);
                }

                dbGameTable.ModifiedDate = DateTimeOffset.Now;

                _gameTableService.EditGameTable(dbGameTable);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            // Komunikat błedu do resources
            return Json("Nie znaleziono stołu do gry o Id=" + gameTableViewModel.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            // Kolejna logika biznesowa zawarta w kontrolerze zamiast w serwisie.
            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = _gameTableService.GetGameTable(gameTableId);
            if (dbGameTable != null)
            {
                foreach (var gameParticipation in gameParticipations)
                {
                    var dbGameParticipation = _gameParticipationService.GetGameParticipation(gameParticipation.Id);
                    if (dbGameParticipation != null)
                        _gameParticipationService.Edit(gameParticipation);
                    else
                        _gameParticipationService.AddGameParticipation(gameParticipation);
                }

                _gameTableService.EditParticipations(gameParticipations, gamer);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            // Komunikat błedu do resources
            return Json("Nie znaleziono stołu do gry o Id=" + gameTableId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _gameTableService.DeleteGameTable(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        
    }
}