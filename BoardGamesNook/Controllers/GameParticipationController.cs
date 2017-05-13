using System;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Controllers
{
    public class GameParticipationController : Controller
    {
        GameParticipationService gameParticipationService = new GameParticipationService(new GameParticipationRepository());

        public JsonResult Get(int id)
        {
            var gameParticipation = gameParticipationService.Get(id);
            return Json(gameParticipation, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameParticipationList = gameParticipationService.GetAll();
            return Json(gameParticipationList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            var gameParticipationList = gameParticipationService.GetAllByTableId(id);
            return Json(gameParticipationList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            //...
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameParticipationViewModel gameParticipation)
        {
            GameParticipation dbGameParticipation = gameParticipationService.Get(gameParticipation.Id);
            if (dbGameParticipation != null)
            {
                //...
                dbGameParticipation.ModifiedDate = DateTimeOffset.Now;

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nie znaleziono uczestnika o Id=" + gameParticipation.Id, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gameParticipationService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}