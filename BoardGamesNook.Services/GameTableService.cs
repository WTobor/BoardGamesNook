using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services
{
    public class GameTableService : IGameTableService
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGameParticipationService _gameParticipationService;
        private readonly IGameResultRepository _gameResultRepository;
        private readonly IGamerService _gamerService;
        private readonly IGameTableRepository _gameTableRepository;

        public GameTableService(IGamerService gamerService, IGameTableRepository gameTableRepository,
            IBoardGameService boardGameService,
            IGameParticipationService gameParticipationService, IGameResultRepository gameResultRepository)
        {
            _gamerService = gamerService;
            _gameTableRepository = gameTableRepository;
            _boardGameService = boardGameService;
            _gameParticipationService = gameParticipationService;
            _gameResultRepository = gameResultRepository;
        }

        public GameTable GetGameTable(int id)
        {
            return _gameTableRepository.Get(id);
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGameListById(int id)
        {
            var gameTable = GetGameTable(id);
            return _gameTableRepository.GetAvailableTableBoardGameList(gameTable);
        }

        public IEnumerable<GameTable> GetAllGameTables()
        {
            return _gameTableRepository.GetAllGameTables();
        }

        public IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname)
        {
            return _gameTableRepository.GetAllGameTablesByGamerNickname(gamerNickname);
        }

        public IEnumerable<GameTable> GetAllGameTablesWithoutResultsByGamerNickname(string gamerNickname)
        {
            var gameTablesWithoutResults = new List<GameTable>();
            var gameTableList = GetAllGameTablesByGamerNickname(gamerNickname);
            foreach (var gameTable in gameTableList)
            {
                var tableResults = _gameResultRepository.GetAllByTableId(gameTable.Id);
                var tableBoardGamesWithResultIds = tableResults.Select(x => x.BoardGameId).ToList();

                if (!tableBoardGamesWithResultIds.SequenceEqual(gameTable.BoardGames.Select(x => x.Id).ToList()))
                {
                    gameTable.BoardGames.RemoveAll(x => tableBoardGamesWithResultIds.Contains(x.Id));
                    gameTablesWithoutResults.Add(gameTable);
                }
            }

            return gameTablesWithoutResults;
        }

        public void CreateGameTable(GameTable gameTable, IEnumerable<int> tableBoardGameIdList)
        {
            gameTable.BoardGames = new List<BoardGame>();
            foreach (var boardGameId in tableBoardGameIdList)
            {
                var boardGame = _boardGameService.Get(boardGameId);
                if (boardGame != null)
                    gameTable.BoardGames.Add(boardGame);
            }

            _gameTableRepository.AddGameTable(gameTable);
        }

        public void EditGameTable(int id, List<int> tableBoardGameIdList)
        {
            var gameTable = GetGameTable(id);
            gameTable.BoardGames = _boardGameService.GetAllByIds(tableBoardGameIdList).ToList();

            _gameTableRepository.EditGameTable(gameTable);
        }

        public void EditGameTableParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer)
        {
            foreach (var gameParticipation in gameParticipations)
            {
                var dbGameParticipation = _gameParticipationService.GetGameParticipation(gameParticipation.Id);
                if (dbGameParticipation != null)
                    _gameParticipationService.Edit(gameParticipation);
                else
                    _gameParticipationService.AddGameParticipation(gameParticipation);
            }

            _gameTableRepository.EditGameTableParticipations(gameParticipations, modifiedGamer);
        }

        public void DeactivateGameTable(int id)
        {
            _gameTableRepository.Deactivate(id);
        }

        public GameTableDto GetGameTableObj(int id)
        {
            var gameTable = GetGameTable(id);
            var tableBoardGameObjs = Mapper.Map<List<TableBoardGameDto>>(gameTable.BoardGames);
            tableBoardGameObjs.ForEach(x => Mapper.Map(gameTable, x));

            var gameTableObjs = MapTableBoardGameObjsToGameTableObjs(tableBoardGameObjs);
            return gameTableObjs.FirstOrDefault();
        }

        public IEnumerable<GameTableDto> GetAllGameTableObjs()
        {
            var gameTableList = GetAllGameTables();
            var gameTableListViewModel = GetTableBoardGameObjs(gameTableList);
            var result = MapTableBoardGameObjsToGameTableObjs(gameTableListViewModel);
            return result;
        }

        public IEnumerable<GameTableDto> GetAllGameTableObjsByGamerNickname(string gamerNickname)
        {
            var gameTableList = GetAllGameTablesByGamerNickname(gamerNickname);
            var tableBoardGameObjs = GetTableBoardGameObjs(gameTableList);
            tableBoardGameObjs.ForEach(x => x.GamerNickname = gamerNickname);

            var result = MapTableBoardGameObjsToGameTableObjs(tableBoardGameObjs);
            return result;
        }

        public IEnumerable<GameTableDto> GetAllGameTableObjsWithoutResultsByGamerNickname(string gamerNickname)
        {
            var gameTableList = GetAllGameTablesWithoutResultsByGamerNickname(gamerNickname);

            var tableBoardGameObjs = Mapper.Map<List<TableBoardGameDto>>(gameTableList);
            tableBoardGameObjs.ForEach(x => x.GamerNickname = gamerNickname);

            var result = MapTableBoardGameObjsToGameTableObjs(tableBoardGameObjs);
            return result;
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGamesById(int id, Gamer gamer)
        {
            var availableTableBoardGameList = GetAvailableTableBoardGameListById(id).ToList();

            return availableTableBoardGameList;
        }

        private List<TableBoardGameDto> GetTableBoardGameObjs(IEnumerable<GameTable> gameTableList)
        {
            var tableBoardGameObjs = new List<TableBoardGameDto>();
            foreach (var gameTable in gameTableList)
                if (gameTable.BoardGames != null)
                    foreach (var boardGame in gameTable.BoardGames)
                    {
                        var gameTableObj = Mapper.Map<TableBoardGameDto>(boardGame);
                        Mapper.Map(gameTable, gameTableObj);
                        gameTableObj.GamerNickname = _gamerService.GetGamer(gameTableObj.GamerId)?.Nickname;
                        tableBoardGameObjs.Add(gameTableObj);
                    }

            return tableBoardGameObjs;
        }

        private List<GameTableDto> MapTableBoardGameObjsToGameTableObjs(
            List<TableBoardGameDto> tableBoardGameObjs)
        {
            var result = new List<GameTableDto>();
            var tables = tableBoardGameObjs.GroupBy(x => x.TableId).ToDictionary(t => t.Key, t => t.ToList());
            foreach (var tableGroup in tables)
            {
                var table = GetGameTable(tableGroup.Key);
                var gameTableViewModel = Mapper.Map<GameTableDto>(table);
                gameTableViewModel.Id = tableGroup.Key;
                gameTableViewModel.TableBoardGameList = tableGroup.Value;
                gameTableViewModel.CreatedGamerNickname =
                    _gamerService.GetGamer(gameTableViewModel.CreatedGamerId)?.Nickname;
                result.Add(gameTableViewModel);
            }

            return result;
        }
    }
}