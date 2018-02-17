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
        private readonly IGamerService _gamerService;
        private readonly IGameTableService _gameTableService;

        public GameTableController(IGameTableService gameTableService, IGamerService gamerService)
        {
            _gameTableService = gameTableService;
            _gamerService = gamerService;
        }

        public JsonResult Get(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTable = _gameTableService.GetGameTable(id);

            var tableBoardGameViewModels = Mapper.Map<List<TableBoardGameViewModel>>(gameTable.BoardGames);
            tableBoardGameViewModels.ForEach(x => Mapper.Map(gameTable, x));

            var result = MapGameTableViewModelListToGameTableList(tableBoardGameViewModels)[0];
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var availableTableBoardGameList = _gameTableService.GetAvailableTableBoardGameListById(id);
            var availableTableBoardGameListViewModel =
                Mapper.Map<IEnumerable<BoardGame>, IEnumerable<TableBoardGameViewModel>>(availableTableBoardGameList);
            foreach (var obj in availableTableBoardGameListViewModel)
                Mapper.Map(gamer, obj);

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableListViewModel = new List<TableBoardGameViewModel>();
            var gameTableList = _gameTableService.GetAllGameTables();
            SetBoardGameTableList(gameTableListViewModel, gameTableList);

            var result = MapGameTableViewModelListToGameTableList(gameTableListViewModel);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            var gameTableListViewModel = new List<TableBoardGameViewModel>();
            var gameTableList = _gameTableService.GetAllGameTablesByGamerNickname(nickname);
            SetBoardGameTableList(gameTableListViewModel, gameTableList);
            gameTableListViewModel.ForEach(x => x.GamerNickname = nickname);

            var result = MapGameTableViewModelListToGameTableList(gameTableListViewModel);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllWithoutResultsByGamerNickname(string nickname)
        {
            var gameTableList = _gameTableService.GetAllGameTablesWithoutResultsByGamerNickname(nickname);

            var gameTableListViewModel = Mapper.Map<List<TableBoardGameViewModel>>(gameTableList);
            gameTableListViewModel.ForEach(x => x.GamerNickname = nickname);

            var result = MapGameTableViewModelListToGameTableList(gameTableListViewModel);

            return Json(result, JsonRequestBehavior.AllowGet);
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


        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTableViewModel)
        {
            var tableBoardGameIdList = gameTableViewModel.TableBoardGameList.Select(x => x.BoardGameId).ToList();
            _gameTableService.EditGameTable(gameTableViewModel.Id, tableBoardGameIdList);

            return Json(null, JsonRequestBehavior.AllowGet);
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

            _gameTableService.EditGameTableParticipations(gameParticipations, gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _gameTableService.DeactivateGameTable(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private List<GameTableViewModel> MapGameTableViewModelListToGameTableList(
            List<TableBoardGameViewModel> gameTableListViewModel)
        {
            var result = new List<GameTableViewModel>();
            var tables = gameTableListViewModel.GroupBy(x => x.TableId).ToDictionary(t => t.Key, t => t.ToList());
            foreach (var tableGroup in tables)
            {
                var table = _gameTableService.GetGameTable(tableGroup.Key);
                var gameTableViewModel = Mapper.Map<GameTableViewModel>(table);
                gameTableViewModel.Id = tableGroup.Key;
                gameTableViewModel.TableBoardGameList = tableGroup.Value;
                gameTableViewModel.CreatedGamerNickname =
                    _gamerService.GetGamer(gameTableViewModel.CreatedGamerId)?.Nickname;
                result.Add(gameTableViewModel);
            }

            return result;
        }

        private GameTable GetGameTableObj(GameTableViewModel gameTableViewModel, Gamer gamer)
        {
            var result = Mapper.Map<GameTable>(gameTableViewModel);
            Mapper.Map(gamer, result);
            return result;
        }

        private void SetBoardGameTableList(List<TableBoardGameViewModel> gameTableListViewModel,
            IEnumerable<GameTable> gameTableList)
        {
            foreach (var gameTable in gameTableList)
                if (gameTable.BoardGames != null)
                    foreach (var boardGame in gameTable.BoardGames)
                    {
                        var gameTableViewModel = Mapper.Map<TableBoardGameViewModel>(boardGame);
                        Mapper.Map(gameTable, gameTableViewModel);
                        gameTableViewModel.GamerNickname = _gamerService.GetGamer(gameTableViewModel.GamerId)?.Nickname;
                        gameTableListViewModel.Add(gameTableViewModel);
                    }
        }
    }
}