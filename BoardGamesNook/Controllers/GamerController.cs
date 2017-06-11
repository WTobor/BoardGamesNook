using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GamerController : Controller
    {
        private GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamer = gamerService.Get(id);
            return Json(gamer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByEmail(string email)
        {
            var gamer = gamerService.GetByEmail(email);
            return Json(gamer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = gamerService.GetAll();
            return Json(gamerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamer)
        {
            gamer.Email = "x";
            Gamer dbGamer = new Gamer()
            {
                Id = gamerService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                Nick = gamer.Nick,
                Name = gamer.Name,
                Surname = gamer.Surname,
                Email = gamer.Email,
                Age = gamer.Age,
                City = gamer.City,
                Street = gamer.Street,
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
            gamerService.Add(dbGamer);

            Session["gamer"] = dbGamer;

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
                return Json("No gamer with Id=" + gamer.Id, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gamerService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}