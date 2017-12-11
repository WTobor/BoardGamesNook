using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardGamesNook.Mappers;
using BoardGamesNook.Model;
using BoardGamesNook.Repository;
using BoardGamesNook.Repository.Generators; // ten namespace nie jest nigdzie używany
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Controllers
{
    [AuthorizeCustom]
    public class GameTableController : Controller
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor
        private GameTableService gameTableService = new GameTableService(new GameTableRepository());
        private BoardGameService boardGameService = new BoardGameService(new BoardGameRepository());
        private GameParticipationService gameParticipationService = new GameParticipationService(new GameParticipationRepository());

        public JsonResult Get(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            var gameTable = new GameTable();
            gameTable.CreatedGamer = gamer;
            gameTable.CreatedGamerId = gamer.Id;
            if (id > 0)
            {
                gameTable = gameTableService.Get(id);
            }
            var gameTableViewModel = GameTableMapper.MapToGameTableViewModel(gameTable);

            return Json(gameTableViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableTableBoardGameList(int id)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            // W repozytoriach metoda "Get" jest dość jednoznaczna, w serwisie już nie.
            // Zmieniłbym tutaj "Get" na "GetGameTable"
            // 
            // Ponadto cały ten kod poniżej (te 7 albo 8 linijek, bez mappera) wygląda mi na jakąś logikę biznesową,
            // więc powinno to wszystko być w serwisie.
            // W tym przypadku metoda Get, mogłaby przyjmować jeszcze obiekt gamer,
            // albo metoda GetAvailableTableBoardGameList przyjmowałaby id gameTable i gamer - nie znam dokładnie biznesu tutaj,
            // więc na szybko nie powiem co lepsze.
            var gameTable = gameTableService.Get(id);
            if (gameTable == null)
            {
                gameTable = new GameTable();
                gameTable.CreatedGamer = gamer;
                gameTable.CreatedGamerId = gamer.Id;
            }
            var availableTableBoardGameList = gameTableService.GetAvailableTableBoardGameList(gameTable);
            // Polecam zapoznać się z biblioteką AutoMapper - dość popularna i dobrze znać, bo często pojawia się na rozmowach rekrutacyjnych.
            // Możesz za pomocą niej stworzyć coś podobnego do GameTableMapper, tylko będzie zajmować dużo mniej kodu.
            // W internecie można znaleźć dość sporo przykładów jak używać AutoMappera.
            // Z reguły sprowadza się to do zarejstrowania go w Global.asax, stworzenia odpowiedniego Profilu, np. GameTableProfile,
            // A potem w kodzie używasz:
            // var availableTableBoardGameListViewModel = Mapper.Map<IEnumerable<TableBoardGameViewModel>>(availableTableBoardGameList).
            // Można mapować kilka obiektów na jeden, wtedy dodajesz chyba kolejną linijkę:
            // availableTableBoardGameListViewModel = Mapper.Map<IEnumerable<TableBoardGameViewModel>>(gameTable),
            // ale to już musiałabyś sprawdzić, bo nie pamiętam do końca.
            var availableTableBoardGameListViewModel = GameTableMapper.MapToTableBoardGameViewModelList(availableTableBoardGameList, gameTable);

            return Json(availableTableBoardGameListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var gameTableList = gameTableService.GetAll();
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByGamerNick(string id)
        {
            var gameTableList = gameTableService.GetAllByGamerNick(id);
            var gameTableListViewModel = GameTableMapper.MapToGameTableViewModelList(gameTableList, id);

            return Json(gameTableListViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(GameTableViewModel model)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }

            // O jejku, to też (tworzenie gameTable) można załatwić Mappera, a jeśli nie, to na pewno powinno takto być w osobnej metodzie,
            // bo aż oczka bolą od takiego czegoś :(
            GameTable gameTable = new GameTable()
            {
                Name = model.Name,
                City = model.City,
                Street = model.Street,
                IsPrivate = model.IsPrivate,
                MinPlayersNumber = model.MinPlayers,
                MaxPlayersNumber = model.MaxPlayers,
                IsFull = false,
                Id = gameTableService.GetAllByGamerNick(gamer.Nick).Select(x => x.Id).LastOrDefault() + 1,
                CreatedGamerId = gamer.Id,
                CreatedGamer = gamer,
                CreatedDate = DateTimeOffset.Now
            };
            var tableBoardGameIdList = model.TableBoardGameList.Select(x => x.BoardGameId).ToList();

            gameTable.BoardGames = new List<BoardGame>();
            foreach (var boardGameId in tableBoardGameIdList)
            {
                var boardGame = boardGameService.Get(boardGameId);
                if (boardGame != null)
                {
                    gameTable.BoardGames.Add(boardGame);
                }
                else
                {
                    return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId, JsonRequestBehavior.AllowGet);
                }
            }
            // Nie wiem czy tutaj nie lepiej byłoby metodę nazwać Create.
            // Add jest dobre do repozytorium, ale w servisie to nie wygląda na jednoznaczną metodę.
            gameTableService.Add(gameTable);
            // Widzę, że w kodzie powyżej masz wołaną metodę "Add" z dwóch serwisów.
            // Ponownie wygląda mi to na jaąś logikę biznesową, która powinna być w serwisie,
            // a nie kontrolerze. Wydaje mi się, że cały kod od linijki 104 do 132 powinien być zawarty w moedzie Add w gameTableService.

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(GameTableViewModel gameTable)
        {
            // Dwie rzeczy:
            // po pierwsze do tych przypisać użyć mappera, albo przenieść je do osobnej metody
            // po drugie - ponownie to jakaś logika biznesowa i powinna być zapewne w metodzie
            // Edit klasy gameTableService.
            GameTable dbGameTable = gameTableService.Get(gameTable.Id); // ten obiekt powinien nazywać się gameTable, a ten z metody gameTableVM albo po prostu gameTableViewModel
            if (dbGameTable != null)
            {
                dbGameTable.City = gameTable.City;
                dbGameTable.Street = gameTable.Street;
                dbGameTable.IsPrivate = gameTable.IsPrivate;
                dbGameTable.MinPlayersNumber = gameTable.MinPlayers;
                dbGameTable.MaxPlayersNumber = gameTable.MaxPlayers;
                var tableBoardGameIdList = gameTable.TableBoardGameList.Select(x => x.BoardGameId).ToList();

                dbGameTable.BoardGames = new List<BoardGame>();
                foreach (var boardGameId in tableBoardGameIdList)
                {
                    var boardGame = boardGameService.Get(boardGameId);
                    if (boardGame != null)
                    {
                        dbGameTable.BoardGames.Add(boardGame);
                    }
                    else
                    {
                        // Nie powinnaś mieć na sztywno nigdzie stringów (komunikatów błędów).
                        // Takie rzecze wrzuca się do Resources - taki dokument można dodać z poziomu Visual Studio, tak jak dodaje się klasę.
                        return Json("Nie znaleziono gry dodanej do stołu o Id=" + boardGameId, JsonRequestBehavior.AllowGet);
                    }
                }

                dbGameTable.ModifiedDate = DateTimeOffset.Now;

                gameTableService.Edit(dbGameTable);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nie znaleziono stołu do gry o Id=" + gameTable.Id, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EditParticipations(List<GameParticipation> gameParticipations)
        {
            Gamer gamer = Session["gamer"] as Gamer;
            if (gamer == null)
            {
                return Json("Nie zalogowano gracza", JsonRequestBehavior.AllowGet);
            }
            // Kolejna logika biznesowa zawarta w kontrolerze zamiast w serwisie.
            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            GameTable dbGameTable = gameTableService.Get(gameTableId);
            if (dbGameTable != null)
            {
                foreach (var gameParticipation in gameParticipations)
                {
                    var dbGameParticipation = gameParticipationService.Get(gameParticipation.Id);
                    if (dbGameParticipation != null)
                    {
                        gameParticipationService.Edit(gameParticipation);
                    }
                    else
                    {
                        gameParticipationService.Add(gameParticipation);
                    }
                }

                gameTableService.EditParticipations(gameParticipations, gamer);

                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nie znaleziono stołu do gry o Id=" + gameTableId, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            gameTableService.Delete(id);

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        // Ta metoda nie jest nigdzie używana, co ona tutaj robi?
        private string GetCurrentGamerId()
        {
            var currentGamer = Session["gamer"] as Gamer;
            var currentGamerId = currentGamer == null ? string.Empty : currentGamer.Id;
            return currentGamerId;
        }
    }
}