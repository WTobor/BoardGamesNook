﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameParticipationController : Controller
    {
        private readonly IGameParticipationService _gameParticipationService;

        public GameParticipationController(IGameParticipationService gameParticipationService)
        {
            _gameParticipationService = gameParticipationService;
        }

        public JsonResult Get(int id)
        {
            var gameParticipation = _gameParticipationService.GetGameParticipation(id);

            var gameParticipationViewModel = Mapper.Map<GameParticipationViewModel>(gameParticipation);
            return Json(gameParticipationViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameParticipationList = _gameParticipationService.GetAllGameParticipations();
            var gameParticipationViewModelList =
                Mapper.Map<IEnumerable<GameParticipationViewModel>>(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByTableId(int id)
        {
            var gameParticipationList = _gameParticipationService.GetAllGameParticipationsByTableId(id);
            var gameParticipationViewModelList =
                Mapper.Map<IEnumerable<GameParticipationViewModel>>(gameParticipationList);
            return Json(gameParticipationViewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameParticipationViewModel gameParticipationViewModel)
        {
            var dbGameParticipation = Mapper.Map<GameParticipation>(gameParticipationViewModel);
            _gameParticipationService.AddGameParticipation(dbGameParticipation);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameParticipationViewModel gameParticipationViewModel)
        {
            var dbGameParticipation = Mapper.Map<GameParticipation>(gameParticipationViewModel);
            _gameParticipationService.Edit(dbGameParticipation);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _gameParticipationService.DeactivateGameParticipation(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}