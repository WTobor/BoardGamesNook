﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
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
        public JsonResult GetByEmail(string email)
        {
            var gamer = _gamerService.GetGamerByEmail(email);
            var gamerViewModel = Mapper.Map<GamerViewModel>(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetByNickname(string nickname)
        {
            var gamer = _gamerService.GetGamerBoardGameByNickname(nickname);
            var gamerViewModel = Mapper.Map<GamerViewModel>(gamer);
            return Json(gamerViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gamerList = _gamerService.GetAllGamers();
            var gamerViewModelList = Mapper.Map<IEnumerable<GamerViewModel>>(gamerList);
            return Json(gamerViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!(Session["user"] is User loggedUser))
                    return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

                var gamer = GetGamerObj(gamerViewModel, loggedUser);
                _gamerService.AddGamer(gamer);

                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var errors = Helpers.GetErrorMessages(ModelState.Values);
            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GamerViewModel gamerViewModel)
        {
            if (!(Session["user"] is User loggedUser))
                return Json(Errors.GamerNotLoggedIn, JsonRequestBehavior.AllowGet);

            var gamer = GetGamerObj(gamerViewModel, loggedUser);

            _gamerService.EditGamer(gamer);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(string id)
        {
            _gamerService.DeactivateGamer(Guid.Parse(id));

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrentGamerNickname()
        {
            var currentGamerNick = !(Session["gamerViewModel"] is Gamer currentGamer)
                ? string.Empty
                : currentGamer.Nickname;
            return Json(currentGamerNick, JsonRequestBehavior.AllowGet);
        }

        private static Gamer GetGamerObj(GamerViewModel gamerViewModel, User loggedUser)
        {
            var result = Mapper.Map<Gamer>(gamerViewModel);
            Mapper.Map(loggedUser, result);
            result.Id = Guid.NewGuid();
            return result;
        }
    }
}