using System;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    public class GameTableController : Controller
    {
        GameTableService gameTableService = new GameTableService(new GameTableRepository());

        public JsonResult Get(int id)
        {
            var gameTable = gameTableService.Get(id);
            var gameTableViewModel = GameTableMapper.MapToGameTableViewModel(gameTable);

            return Json(gameTableViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = gameTableService.GetAll();
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerId(int id)
        {
            var gameTableList = gameTableService.GetAllByGamerId(id);
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList, id);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            //...
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTable)
        {
            GameTable dbGameTable = gameTableService.Get(gameTable.Id);
            if (dbGameTable != null)
            {
                //...
                dbGameTable.ModifiedDate = DateTimeOffset.Now;

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
    }
}