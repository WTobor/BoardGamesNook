using System;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerController : Controller
    {
        private readonly GamerService _gamerService = new GamerService(new GamerRepository());

        [HttpPost]
        public JsonResult GetByEmail(string email)
        {
            var gamer = _gamerService.GetByEmail(email);
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
            var gamerList = _gamerService.GetAll();
            var gamerViewModelList = GamerMapper.MapToGamerList(gamerList);
            return Json(gamerViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamer)
        {
            if (!(Session["user"] is User loggedUser))
            {
                return Json("Nie znaleziono użytkownika", JsonRequestBehavior.AllowGet);
            }

            if (_gamerService.NickExists(gamer.Nick))
                return Json("Istnieje gracz o podanym nicku. Wybierz inny nick.", JsonRequestBehavior.AllowGet);

            var dbGamer = new Gamer
            {
                Id = Guid.NewGuid().ToString(),
                Nick = gamer.Nick,
                Name = gamer.Name,
                Surname = gamer.Surname,
                Email = loggedUser.Email,
                Age = gamer.Age,
                City = gamer.City,
                Street = gamer.Street,
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
            _gamerService.Add(dbGamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Gamer gamer)
        {
            var dbGamer = _gamerService.Get(gamer.Id);
            if (dbGamer != null)
            {
                dbGamer.Name = gamer.Name;
                dbGamer.Surname = gamer.Surname;
                dbGamer.Age = gamer.Age;
                dbGamer.City = gamer.City;
                dbGamer.Street = gamer.Street;
                dbGamer.ModifiedDate = DateTimeOffset.Now;
            }
            else
            {
                return Json("Brak gracza o Id=" + gamer.Id, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(string id)
        {
            _gamerService.Deactivate(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public string GetCurrentGamerNick()
        {
            var currentGamerNick = !(Session["gamer"] is Gamer currentGamer) ? string.Empty : currentGamer.Nick;
            return currentGamerNick;
        }
    }
}