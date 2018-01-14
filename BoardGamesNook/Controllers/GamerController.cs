using System;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerController : Controller
    {
        private readonly IGamerService _gamerService;

        public GamerController(IGamerService gamerService)
        {
            _gamerService = gamerService;
        }

        [HttpPost]
        public JsonResult GetGamerByEmail(string email)
        {
            var gamer = _gamerService.GetGamerByEmail(email);
            var gamerViewModel = GamerMapper.MapToGamerViewModel(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetByNick(string nick)
        {
            var gamer = _gamerService.GetByNick(nick);
            var gamerViewModel = GamerMapper.MapToGamerViewModel(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = _gamerService.GetAllGamers();
            var gamerViewModelList = GamerMapper.MapToGamerList(gamerList);
            return Json(gamerViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamerViewModel)
        {
            if (!(Session["user"] is User loggedUser))
                return Json("Nie znaleziono użytkownika", JsonRequestBehavior.AllowGet);

            if (_gamerService.NickExists(gamerViewModel.Nick))
                return Json("Istnieje gracz o podanym nicku. Wybierz inny nick.", JsonRequestBehavior.AllowGet);
            var gamer = GetGamerObj(gamerViewModel, loggedUser);
            _gamerService.AddGamer(gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Gamer gamer)
        {
            _gamerService.EditGamer(gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(string id)
        {
            _gamerService.DeactivateGamer(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private static Gamer GetGamerObj(GamerViewModel gamerViewModel, User loggedUser)
        {
            return new Gamer
            {
                Id = Guid.NewGuid().ToString(),
                Nick = gamerViewModel.Nick,
                Name = gamerViewModel.Name,
                Surname = gamerViewModel.Surname,
                Email = loggedUser.Email,
                Age = gamerViewModel.Age,
                City = gamerViewModel.City,
                Street = gamerViewModel.Street,
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
        }
    }
}