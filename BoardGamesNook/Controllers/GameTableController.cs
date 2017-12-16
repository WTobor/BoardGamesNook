using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameTableController : Controller
    {
        private readonly BoardGameService _boardGameService = new BoardGameService(new BoardGameRepository());

        private readonly GameParticipationService _gameParticipationService =
            new GameParticipationService(new GameParticipationRepository());

        private readonly GameTableService _gameTableService = new GameTableService(new GameTableRepository());

        public JsonResult Get(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            var gameTable = new GameTable
            {
                CreatedGamer = gamer,
                CreatedGamerId = gamer.Id
            };
            if (id > 0)
                gameTable = _gameTableService.Get(id);
            var gameTableViewModel = GameTableMapper.MapToGameTableViewModel(gameTable);

            return Json(gameTableViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            var gameTable = _gameTableService.Get(id);
            if (gameTable == null)
            {
                gameTable = new GameTable
                {
                    CreatedGamer = gamer,
                    CreatedGamerId = gamer.Id
                };
            }
            var availableTableBoardGameList = _gameTableService.GetAvailableTableBoardGameList(gameTable);
            var availableTableBoardGameListViewModel =
                GameTableMapper.MapToTableBoardGameViewModelList(availableTableBoardGameList, gameTable);

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = _gameTableService.GetAll();
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            var gameTableList = _gameTableService.GetAllByGamerNick(id);
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList, id);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);

            var gameTable = new GameTable
            {
                Name = model.Name,
                City = model.City,
                Street = model.Street,
                IsPrivate = model.IsPrivate,
                MinPlayersNumber = model.MinPlayers,
                MaxPlayersNumber = model.MaxPlayers,
                IsFull = false,
                Id = _gameTableService.GetAllByGamerNick(gamer.Nick).Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                CreatedGamer = gamer,
                CreatedDate = DateTimeOffset.Now
            };
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

            _gameTableService.Add(gameTable);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTable)
        {
            var dbGameTable = _gameTableService.Get(gameTable.Id);
            if (dbGameTable != null)
            {
                dbGameTable.City = gameTable.City;
                dbGameTable.Street = gameTable.Street;
                dbGameTable.IsPrivate = gameTable.IsPrivate;
                dbGameTable.MinPlayersNumber = gameTable.MinPlayers;
                dbGameTable.MaxPlayersNumber = gameTable.MaxPlayers;
                var tableBoardGameIdList = gameTable.TableBoardGameList.Select(x => x.BoardGameId).ToList();

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

                _gameTableService.Edit(dbGameTable);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono stołu do gry o Id=" + gameTable.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            if (!(Session["gamer"] is Gamer gamer))
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = _gameTableService.Get(gameTableId);
            if (dbGameTable != null)
            {
                foreach (var gameParticipation in gameParticipations)
                {
                    var dbGameParticipation = _gameParticipationService.Get(gameParticipation.Id);
                    if (dbGameParticipation != null)
                        _gameParticipationService.Edit(gameParticipation);
                    else
                        _gameParticipationService.Add(gameParticipation);
                }

                _gameTableService.EditParticipations(gameParticipations, gamer);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono stołu do gry o Id=" + gameTableId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _gameTableService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private string GetCurrentGamerId()
        {
            var currentGamerId = !(Session["gamer"] is Gamer currentGamer)
                ? string.Empty : currentGamer.Id;
            return currentGamerId;
        }
    }
}