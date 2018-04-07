using System.Web.Mvc;
using AutoMapper;
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
            var boardGameList = _boardGameService.GetAll();
            return Json(boardGameList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            // What this method is doing? It is adding name to some random thing? You should call this method cleary, that it will be easy to understand
            var result = _boardGameService.AddOrGetSimilar(name);
            if (result == null)
                return Json(string.Format(Errors.BoardGameWithNameNotFound, name), JsonRequestBehavior.AllowGet);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddFromBGGById(int id)
        {
            var boardGame = _boardGameService.GetBGGBoardGameById(id);
            if (boardGame == null)
                return Json(string.Format(Errors.BoardGameWithIdNotFound, id), JsonRequestBehavior.AllowGet);
            _boardGameService.Add(boardGame);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(BoardGameViewModel boardGameViewModel)
        {
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