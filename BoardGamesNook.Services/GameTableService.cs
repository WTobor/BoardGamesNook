using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GameTableService : IGameTableService
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGameParticipationService _gameParticipationService;
        private readonly IGameTableRepository _gameTableRepository;
        private readonly IGameResultRepository _gameResultRepository;

        public GameTableService(IGameTableRepository gameTableRepository, IBoardGameService boardGameService,
            IGameParticipationService gameParticipationService, IGameResultRepository gameResultRepository)
        {
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
    }
}