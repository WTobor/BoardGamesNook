using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using BoardGameGeekIntegration;
using BoardGameGeekIntegration.Models;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.BoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class BoardGameController : ApiController
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<BoardGame> Get(int id)
        {
            var boardGame = _boardGameService.Get(id);
            return Json(boardGame);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<IEnumerable<BoardGame>> GetAll()
        {
            var boardGameList = _boardGameService.GetAll();
            return Json(boardGameList);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<List<SimilarBoardGame>> Add(string name)
        {
            var result = _boardGameService.AddOrGetSimilar(name);
            //if (result == null)
            //    return Json(string.Format(Errors.BoardGameWithNameNotFound, name));

            return Json(result);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<string> AddById(int id)
        {
            var boardGame = BGGBoardGame.GetBoardGameById(id);
            if (boardGame == null)
                return Json(string.Format(Errors.BoardGameWithIdNotFound, id));
            _boardGameService.Add(boardGame);
            return Json("");
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<string> Edit(BoardGameViewModel boardGameViewModel)
        {
            var dbBoardGame = _boardGameService.Get(boardGameViewModel.Id);
            if (dbBoardGame == null)
                return Json(string.Format(Errors.BoardGameWithIdNotFound, boardGameViewModel.Id));
            var boardGame = Mapper.Map<BoardGame>(boardGameViewModel);
            _boardGameService.Edit(boardGame);

            return Json("");
        }


        [System.Web.Mvc.HttpPost]
        public JsonResult<string> Deactivate(int id)
        {
            _boardGameService.DeactivateBoardGame(id);
            return Json("");
        }
    }
}