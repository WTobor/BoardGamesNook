using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BoardGameGeekIntegration;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.ViewModels.BoardGame;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }


        public JsonResult Get(int id)
        {
            var boardGame = _boardGameService.Get(id);
            return Json(boardGame, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var boardGameList = _boardGameService.GetAllGamerBoardGames();
            return Json(boardGameList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            var result = _boardGameService.AddOrGetSimilar(name);
            if (result == null)
                return Json(string.Format(Errors.BoardGameWithNameNotFound, name), JsonRequestBehavior.AllowGet);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddById(int id)
        {
            var boardGame = BGGBoardGame.GetBoardGameById(id);
            if (boardGame == null)
                return Json(string.Format(Errors.BoardGameWithIdNotFound, id), JsonRequestBehavior.AllowGet);
            _boardGameService.Add(boardGame);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGameViewModel boardGameViewModel)
        {
            var dbBoardGame = _boardGameService.Get(boardGameViewModel.Id);
            if (dbBoardGame == null)
                return Json(string.Format(Errors.BoardGameWithIdNotFound, boardGameViewModel.Id),
                    JsonRequestBehavior.AllowGet);
            var boardGame = Mapper.Map<BoardGame>(boardGameViewModel);
            _boardGameService.Edit(boardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Deactivate(int id)
        {
            _boardGameService.DeactivateBoardGame(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}