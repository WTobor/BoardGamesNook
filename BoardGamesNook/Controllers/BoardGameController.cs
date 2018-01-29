using System.Linq;
using System.Web.Mvc;
using BoardGameGeekIntegration;
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
            // Tutaj również jakaś logika biznesowa, która powinna być w serwisie.
            var boardGameId = BGGBoardGame.GetBoardGameId(name);
            if (boardGameId != 0)
            {
                var boardGame = BGGBoardGame.GetBoardGameById(boardGameId);
                boardGame.Id = _boardGameService.GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1;
                _boardGameService.Add(boardGame);
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var similarBoardGameList = BGGBoardGame.GetSimilarBoardGameList(name);
            if (similarBoardGameList.Count > 0)
                return Json(similarBoardGameList.Take(10), JsonRequestBehavior.AllowGet);

            return Json(string.Format(Errors.BoardGameWithNameNotFound, name), JsonRequestBehavior.AllowGet);
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
            _boardGameService.Edit(dbBoardGame);

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            _boardGameService.Delete(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}