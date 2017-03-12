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
        public JsonResult Get()
        {
            var gamer = new Gamer()
            {
                Active = true,
                Age = 5,
                Nick = "testNick",
                Name = "testName",
                Surname = "testSurname",
                City = "Wrocław",
                Street = "tmp"
            };
            return Json(gamer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            ViewBag.Message = "GetAll";

            var gamerList = gamerService.GetAll();
            IEnumerable<Gamer> items = new Gamer[] { new Gamer()
            {
                Active = true,
                Age = 5,
                Nick = "testNick",
                Name = "testName",
                Surname = "testSurname",
                City = "Wrocław",
                Street = "tmp"
            } };
            items = items.Concat(new[]
            {
                new Gamer()
                {
                    Active = true,
                    Age = 51,
                    Nick = "testNick1",
                    Name = "testName1",
                    Surname = "testSurname1",
                    City = "Wrocław1",
                    Street = "tmp1"
                }
            });
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add()
        {
            ViewBag.Message = "Add";

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit()
        {
            ViewBag.Message = "Edit";

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete()
        {
            ViewBag.Message = "Delete";

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}