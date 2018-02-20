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
    // This controller is so big that is hard to navigate in it. You should start creating smaller controllers. Read some more about REST API.
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

            var gameTableObj = _gameTableService.GetGameTableObj(id);
            var result = Mapper.Map<GameTableViewModel>(gameTableObj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var availableTableBoardGameObjs = _gameTableService.GetAvailableTableBoardGameObjsById(id, gamer);
            var result = Mapper.Map<List<TableBoardGameViewModel>>(availableTableBoardGameObjs);

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
            var result = Mapper.Map<List<GameTable>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllWithoutResultsByGamerNickname(string nickname)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gameTableObjs = _gameTableService.GetAllGameTableObjsWithoutResultsByGamerNickname(nickname);
            var result = Mapper.Map<List<GameTable>>(gameTableObjs);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            if (!(Session["gamer"] is Gamer gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);
            // What this is doing? I can see some business logic here, but I can't tell is it needed or not, because i do not understand this code.
            //here is a problem - I cannot trasfer ViewModel to Services; first I need to map it - and that's exactly what's happening here
            var gameTable = GetGameTableObj(model, gamer);
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            _gameTableService.CreateGameTable(gameTable, tableBoardGameIdList);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private GameTable GetGameTableObj(GameTableViewModel gameTableViewModel, Gamer gamer)
        {
            var result = Mapper.Map<GameTable>(gameTableViewModel);
            Mapper.Map(gamer, result);
            return result;
        }

        [HttpPost]
        public JsonResult Edit(EditTableBoardGameViewModel editTableBoardGame)
        {
            if (!(Session["gamer"] is Gamer))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            _gameTableService.EditGameTable(editTableBoardGame.Id, editTableBoardGame.TableBoardGameIdList);
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