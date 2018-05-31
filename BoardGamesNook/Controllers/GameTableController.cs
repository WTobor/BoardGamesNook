using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.Services.Models;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    // AM: This controller is so big that is hard to navigate in it. You should start creating smaller controllers. Please read some more about REST API.
    public class GameTableController : Controller
    {
        private readonly IGameTableService _gameTableService;

        public GameTableController(IGameTableService gameTableService)
        {
            _gameTableService = gameTableService;
        }

        public JsonResult Get(int id)
        {
            var gameTableObj = _gameTableService.GetGameTableObj(id);
            var result = Mapper.Map<GameTableViewModel>(gameTableObj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            var availableTableBoardGames =
                _gameTableService.GetAvailableTableBoardGamesById(id, Session["gamer"] as Gamer);
            var result = Mapper.Map<List<TableBoardGameDto>>(availableTableBoardGames);
            foreach (var obj in result)
                Mapper.Map(Session["gamer"] as Gamer, obj);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableObjs = _gameTableService.GetAllGameTableObjs();
            var result = Mapper.Map<List<GameTableViewModel>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            var gameTableObjs = _gameTableService.GetAllGameTableObjsByGamerNickname(nickname);
            var result = Mapper.Map<List<GameTableViewModel>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllWithoutResultsByGamerNickname(string nickname)
        {
            var gameTableObjs = _gameTableService.GetAllGameTableObjsWithoutResultsByGamerNickname(nickname);
            // AM: Controllers should always return view models.
            var result = Mapper.Map<List<GameTable>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            // AM: What this is doing? I can see some business logic here, but I can't tell is it needed or not, because i do not understand this code.
            // WT: here is a problem - I cannot trasfer ViewModel to Services; first I need to map it - and that's exactly what's happening here
            // AM: Ok, i understand. It just looking strange for me, for example why GameTableViewModel has List of TableBoardGameViewModel, if you only need List of BoardGameId? It does not look like a good practis.
            // WT: because I need to map this model to gameTable
            var gameTable = GetGameTable(model, Session["gamer"] as Gamer);
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            _gameTableService.CreateGameTable(gameTable, tableBoardGameIdList);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private GameTable GetGameTable(GameTableViewModel gameTableViewModel, Gamer gamer)
        {
            var result = Mapper.Map<GameTable>(gameTableViewModel);
            Mapper.Map(gamer, result);
            return result;
        }

        [HttpPost]
        public JsonResult Edit(EditTableBoardGameViewModel editTableBoardGame)
        {
            _gameTableService.EditGameTable(editTableBoardGame.Id, editTableBoardGame.TableBoardGameIdList);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            _gameTableService.EditGameTableParticipations(gameParticipations, Session["gamer"] as Gamer);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _gameTableService.DeactivateGameTable(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}