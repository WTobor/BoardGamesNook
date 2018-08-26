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
    public class GameTableController : Controller
    {
        private readonly IGameTableService _gameTableService;

        public GameTableController(IGameTableService gameTableService)
        {
            _gameTableService = gameTableService;
        }

        public JsonResult Get(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableObj = _gameTableService.GetGameTableObj(id);
            var result = Mapper.Map<GameTableViewModel>(gameTableObj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var availableTableBoardGames = _gameTableService.GetAvailableTableBoardGamesById(id, gamer);
            var result = Mapper.Map<List<TableBoardGameDto>>(availableTableBoardGames);
            foreach (var obj in result)
                Mapper.Map(gamer, obj);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableObjs = _gameTableService.GetAllGameTableObjs();
            var result = Mapper.Map<List<GameTableViewModel>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableObjs = _gameTableService.GetAllGameTableObjsByGamerNickname(nickname);
            var result = Mapper.Map<List<GameTableViewModel>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllWithoutResultsByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableObjs = _gameTableService.GetAllGameTableObjsWithoutResultsByGamerNickname(nickname);
            var result = Mapper.Map<List<GameTableViewModel>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(Session["gamer"] is Gamer gamer))
                    return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

                var gameTable = GetGameTable(model, gamer);
                var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

                _gameTableService.CreateGameTable(gameTable, tableBoardGameIdList);

                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var errors = Helpers.GetErrorMessages(ModelState.Values);
            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        private GameTable GetGameTable(GameTableViewModel gameTableViewModel, Gamer gamer)
        {
            var result = Mapper.Map<GameTable>(gameTableViewModel);
            Mapper.Map(gamer, result);
            return result;
        }

        [HttpPost]
        public JsonResult Edit(int gameTableId, List<int> tableBoardGameId)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameTableService.EditGameTable(gameTableId, tableBoardGameId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameTableService.EditGameTableParticipations(gameParticipations, gamer);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameTableService.DeactivateGameTable(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}