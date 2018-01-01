using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameParticipationController : Controller
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor
        private GameParticipationService gameParticipationService = new GameParticipationService(new GameParticipationRepository());

        public JsonResult Get(int id)
        {
            var gameParticipation = gameParticipationService.Get(id);
            // Użycie AutoMappera
            var gameParticipationViewModel = GameParticipationMapper.MapToGameParticipationViewModel(gameParticipation);
            return Json(gameParticipationViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameParticipationList = gameParticipationService.GetAll();
            // Użycie AutoMappera
            var gameParticipationViewModelList = GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            var gameParticipationList = gameParticipationService.GetAllByTableId(id);
            // Użycie AutoMappera
            var gameParticipationViewModelList = GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameParticipationViewModel gameParticipation)
        {
            // Użycie AutoMappera
            var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
            gameParticipationService.Add(dbGameParticipation);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameParticipationViewModel gameParticipation)
        {
            // To również wygląda na jakąś logikę biznesową, która powinna być w serwisie
            GameParticipation orgGameParticipation = gameParticipationService.Get(gameParticipation.Id);
            if (orgGameParticipation != null)
            {
                // Użycie AutoMappera
                var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
                gameParticipationService.Edit(dbGameParticipation);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Komunikat błedu do resources
                return Json("Nie znaleziono uczestnika gry o Id=" + gameParticipation.Id, JsonRequestBehavior.AllowGet);
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