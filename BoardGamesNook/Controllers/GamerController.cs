using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Linq; // ten namespace nie jest nigdzie używany
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerController : Controller
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor
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

            // Tworzenie obiektu Gamer powinno być w osobnej metodzie.
            // Masz również lekką niespójność w nazwach zmiennych. Czasami parametr metody nazywa się u Ciebie "model", a czasami tak jak konkretny typ.
            // Powinno być to jednolite.
            // Dodatkowo jeśli już chcesz, aby nazywało się tak jak konkretny typ, to nazwa powinna być "gamerViewModel",
            // aby zmienna typu "Gamer" mogła nazywać się "gamer".
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
            // Controller nie powinien zajmować się edycją obiektu, to powinno odbywać się w serwisie.
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
                // Komunikat błedu do resources
                return Json("Brak gracza o Id=" + gamer.Id, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(string id)
        {
            gamerService.Deactivate(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        // Tutaj również chyba chodziło Ci o "Nickname"
        public string GetCurrentGamerNick()
        {
            var currentGamer = Session["gamer"] as Gamer;
            var currentGamerNick = currentGamer == null ? string.Empty : currentGamer.Nick;
            return currentGamerNick;
        }
    }
}