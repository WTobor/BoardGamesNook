using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameParticipationController : Controller
    {
        private readonly IGameParticipationService _gameParticipationService;

        public GameParticipationController(IGameParticipationService gameParticipationService)
        {
            _gameParticipationService = gameParticipationService;
        }

        public JsonResult Get(int id)
        {
            var gameParticipation = _gameParticipationService.Get(id);
            // Użycie AutoMappera
            var gameParticipationViewModel = GameParticipationMapper.MapToGameParticipationViewModel(gameParticipation);
            return Json(gameParticipationViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameParticipationList = _gameParticipationService.GetAll();
            // Użycie AutoMappera
            var gameParticipationViewModelList =
                GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            var gameParticipationList = _gameParticipationService.GetAllByTableId(id);
            // Użycie AutoMappera
            var gameParticipationViewModelList =
                GameParticipationMapper.MapToGameParticipationViewModelList(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameParticipationViewModel gameParticipation)
        {
            // Użycie AutoMappera
            var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
            _gameParticipationService.Add(dbGameParticipation);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameParticipationViewModel gameParticipation)
        {
            // To również wygląda na jakąś logikę biznesową, która powinna być w serwisie
            var orgGameParticipation = _gameParticipationService.Get(gameParticipation.Id);
            if (orgGameParticipation != null)
            {
                // Użycie AutoMappera
                var dbGameParticipation = GameParticipationMapper.MapToGameParticipation(gameParticipation);
                _gameParticipationService.Edit(dbGameParticipation);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            // Komunikat błedu do resources
            return Json("Nie znaleziono uczestnika gry o Id=" + gameParticipation.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _gameParticipationService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}