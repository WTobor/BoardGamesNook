using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.Repository;

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
            ViewBag.Message = "GetAll";

            var gamerList = gamerService.GetAll();
            return Json(gamerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string nick, string name, string surname, int age, string city, string street)
        {
            ViewBag.Message = "Add";

            Gamer gamer = new Gamer()
            {
                Nick = nick,
                Name = name,
                Surname = surname,
                Age = age,
                City = city,
                Street = street
            };

            gamerService.Add(gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Gamer gamer)
        //public JsonResult Edit(int id, string name, string surname, int age, string city, string street)
        {

            ViewBag.Message = "Edit";

            Gamer dbGamer = gamerService.Get(gamer.Id);
            if (dbGamer != null)
            {
                dbGamer.Name = gamer.Name;
                dbGamer.Surname = gamer.Surname;
                dbGamer.Age = gamer.Age;
                dbGamer.City = gamer.City;
                dbGamer.Street = gamer.Street;
            }
            else
            {
                return Json("No gamer with Id=" + gamer.Id, JsonRequestBehavior.AllowGet);
            }

            var gamers = gamerService.GetAll();

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        { 
            ViewBag.Message = "Delete";

            gamerService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}