using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameParticipationController : Controller
    {
        private readonly GameParticipationService gameParticipationService =
            new GameParticipationService(new GameParticipationRepository());

        public JsonResult Get(int id)
        {
            var gameParticipation = gameParticipationService.Get(id);
            var gameParticipationViewModel = GameParticipationMapper.MapToGameParticipationViewModel(gameParticipation);
            return Json(gameParticipationViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameParticipationList = gameParticipationService.GetAll();
            var gameParticipationViewModelList =
                GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            var gameParticipationList = gameParticipationService.GetAllByTableId(id);
            var gameParticipationViewModelList =
                GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameParticipationViewModel gameParticipation)
        {
            var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
            gameParticipationService.Add(dbGameParticipation);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameParticipationViewModel gameParticipation)
        {
            var orgGameParticipation = gameParticipationService.Get(gameParticipation.Id);
            if (orgGameParticipation != null)
            {
                var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
                gameParticipationService.Edit(dbGameParticipation);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json("Nie znaleziono uczestnika gry o Id=" + gameParticipation.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gameParticipationService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}