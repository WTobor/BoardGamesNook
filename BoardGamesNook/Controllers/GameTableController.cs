using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameTableController : Controller
    {
        private GameTableService gameTableService = new GameTableService(new GameTableRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameTable = new GameTable();
            gameTable.CreatedGamer = gamer;
            gameTable.CreatedGamerId = gamer.Id;
            if (id > 0)
            {
                gameTable = gameTableService.Get(id);
            }
            var gameTableViewModel = GameTableMapper.MapToGameTableViewModel(gameTable);

            return Json(gameTableViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameTable = gameTableService.Get(id);
            if (gameTable == null)
            {
                gameTable = new GameTable();
                gameTable.CreatedGamer = gamer;
                gameTable.CreatedGamerId = gamer.Id;
            }
            var availableTableBoardGameList = gameTableService.GetAvailableTableBoardGameList(gameTable);
            var availableTableBoardGameListViewModel = GameTableMapper.MapToTableBoardGameViewModelList(availableTableBoardGameList, gameTable);

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = gameTableService.GetAll();
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            var gameTableList = gameTableService.GetAllByGamerNick(id);
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList, id);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            GameTable gameTable = new GameTable()
            {
                City = model.City,
                Street = model.Street,
                IsPrivate = model.IsPrivate,
                MinPlayersNumber = model.MinPlayers,
                MaxPlayersNumber = model.MaxPlayers,
                IsFull = false,
                Id = gameTableService.GetAllByGamerNick(gamer.Nick).Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                CreatedGamer = gamer,
                CreatedDate = DateTimeOffset.Now
            };
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            gameTable.BoardGames = new List<BoardGame>();
            foreach (var boardGameId in tableBoardGameIdList)
            {
                var boardGame = boardGameService.Get(boardGameId);
                if (boardGame != null)
                {
                    gameTable.BoardGames.Add(boardGame);
                }
                else
                {
                    return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId, JsonRequestBehavior.AllowGet);
                }
            }

            gameTableService.Add(gameTable);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTable)
        {
            GameTable dbGameTable = gameTableService.Get(gameTable.Id);
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
                    var boardGame = boardGameService.Get(boardGameId);
                    if (boardGame != null)
                    {
                        dbGameTable.BoardGames.Add(boardGame);
                    }
                    else
                    {
                        return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId, JsonRequestBehavior.AllowGet);
                    }
                }

                dbGameTable.ModifiedDate = DateTimeOffset.Now;

                gameTableService.Edit(dbGameTable);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nie znaleziono stołu do gry o Id=" + gameTable.Id, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gameTableService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private string GetCurrentGamerId()
        {
            var currentGamer = Session["gamer"] as Gamer;
            var currentGamerId = currentGamer == null ? string.Empty : currentGamer.Id;
            return currentGamerId;
        }
    }
}