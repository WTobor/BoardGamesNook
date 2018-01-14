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
            var gamerViewModelList = Mapper.Map<List<GamerViewModel>>(gamerList);
            return Json(gamerViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GamerViewModel gamerViewModel)
        {
            if (!(Session["user"] is User loggedUser))
                return Json("Nie znaleziono użytkownika", JsonRequestBehavior.AllowGet);

            if (_gamerService.NicknameExists(gamerViewModel.Nickname))
                return Json("Istnieje gracz o podanym nicku. Wybierz inny nickname.", JsonRequestBehavior.AllowGet);
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

        public string GetCurrentGamerNickname()
        {
            var currentGamerNick = !(Session["gamer"] is Gamer currentGamer) ? string.Empty : currentGamer.Nickname;
            return currentGamerNick;
        }

        private static Gamer GetGamerObj(GamerViewModel gamerViewModel, User loggedUser)
        {
            return new Gamer
            {
                Id = Guid.NewGuid().ToString(),
                Nickname = gamerViewModel.Nickname,
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