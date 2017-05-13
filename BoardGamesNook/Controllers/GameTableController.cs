using System;
using System.Web.Mvc;
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
            return Json(gameTable, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = gameTableService.GetAll();
            return Json(gameTableList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByUserId(int id)
        {
            var gameTableList = gameTableService.GetAllByUserId(id);
            return Json(gameTableList, JsonRequestBehavior.AllowGet);
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