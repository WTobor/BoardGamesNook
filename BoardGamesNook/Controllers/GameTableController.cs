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
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
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
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
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
            foreach (var obj in availableTableBoardGameListViewModel)
                Mapper.Map(gamer, obj);

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableListViewModel = new List<TableBoardGameViewModel>();
            var gameTableList = _gameTableService.GetAllGameTables();

            foreach (var gameTable in gameTableList)
                if (gameTable.BoardGames != null)
                    foreach (var boardGame in gameTable.BoardGames)
                    {
                        var gameTableViewModel = Mapper.Map<TableBoardGameViewModel>(boardGame);
                        Mapper.Map(gameTable, gameTableViewModel);
                        gameTableListViewModel.Add(gameTableViewModel);
                    }

            //poprawić wyświetlanie, bo nie działa
            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            var gameTableList = _gameTableService.GetAllGameTablesByGamerNickname(nickname);
            var gameTableListViewModel = Mapper.Map<List<TableBoardGameViewModel>>(gameTableList);
            gameTableListViewModel.ForEach(x => x.GamerNickname = nickname);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            var gameTable = GetGameTableObj(model, gamer);
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            _gameTableService.CreateGameTable(gameTable, tableBoardGameIdList);

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
                Id = _gameTableService.GetAllGameTablesByGamerNickname(gamer.Nickname).Select(x => x.Id)
                         .LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                CreatedGamer = gamer,
                CreatedDate = DateTimeOffset.Now
            };
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTableViewModel)
        {
            // ponownie to jakaś logika biznesowa i powinna być zapewne w metodzie
            // EditGameTable klasy gameTableService.
            //WT: a co z faktem, że jest to VM i w serwisie nie mam dostępu do tego obiektu?
            var dbGameTable =
                _gameTableService.GetGameTable(gameTableViewModel
                    .Id);

            if (dbGameTable != null)
            {
                Mapper.Map(gameTableViewModel, dbGameTable);

                var tableBoardGameIdList = gameTableViewModel.TableBoardGameList.Select(x => x.BoardGameId).ToList();

                dbGameTable.BoardGames = _boardGameService.GetAllByIds(tableBoardGameIdList);

                _gameTableService.EditGameTable(dbGameTable);

                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(string.Format(Errors.BoardGameTableWithIdNotFound, gameTableViewModel.Id),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = _gameTableService.GetGameTable(gameTableId);
            if (dbGameTable == null)
                return Json(string.Format(Errors.BoardGameTableWithIdNotFound, gameTableId),
                    JsonRequestBehavior.AllowGet);

            _gameTableService.EditParticipations(gameParticipations, gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _gameTableService.DeleteGameTable(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}