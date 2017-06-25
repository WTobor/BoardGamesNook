using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerController : Controller
    {
        private GamerService gamerService = new GamerService(new GamerRepository());

        [HttpPost]
        public JsonResult GetByEmail(string email)
        {
            var gamer = gamerService.GetByEmail(email);
            var gamerViewModel = GamerMapper.MapToGamerViewModel(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetByNick(string nick)
        {
            var gamer = gamerService.GetByNick(nick);
            var gamerViewModel = GamerMapper.MapToGamerViewModel(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = gamerService.GetAll();
            var gamerViewModelList = GamerMapper.MapToGamerList(gamerList);
            return Json(gamerViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamer)
        {
            User loggedUser = Session["user"] as User;
            if (loggedUser == null)
            {
                return Json("Nie znaleziono użytkownika", JsonRequestBehavior.AllowGet);
            }

            if (gamerService.NickExists(gamer.Nick))
            {
                return Json("Istnieje gracz o podanym nicku. Wybierz inny nick.", JsonRequestBehavior.AllowGet);
            }

            Gamer dbGamer = new Gamer()
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
            gamerService.Add(dbGamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Gamer gamer)
        {
            Gamer dbGamer = gamerService.Get(gamer.Id);
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
        public JsonResult Delete(string id)
        {
            gamerService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public string GetCurrentGamerNick()
        {
            var currentGamer = Session["gamer"] as Gamer;
            var currentGamerNick = currentGamer == null ? string.Empty : currentGamer.Nick;
            return currentGamerNick;
        }
    }
}