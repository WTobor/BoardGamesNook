using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BoardGamesNook.Controllers
{
    public class GamerController :Controller
    {
        GamerService gamerService = new GamerService(new GamerRepository());

        public JsonResult Get(int id)
        {
            var gamer = gamerService.Get(id);
            return Json(gamer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = gamerService.GetAll();
            return Json(gamerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string nick, string name, string surname, int age, string city, string street)
        {
            Gamer gamer = new Gamer()
            {
                Id = gamerService.GetAll().Select(x => x.Id).LastOrDefault() + 1,
                Nick = nick,
                Name = name,
                Surname = surname,
                Age = age,
                City = city,
                Street = street,
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
            gamerService.Add(gamer);

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