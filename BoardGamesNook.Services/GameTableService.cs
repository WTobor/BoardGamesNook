using System.Collections.Generic;
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

        public GameTableService(IGameTableRepository gameTableRepository, IBoardGameService boardGameService,
            IGameParticipationService gameParticipationService)
        {
            _gameTableRepository = gameTableRepository;
            _boardGameService = boardGameService;
            _gameParticipationService = gameParticipationService;
        }

        public GameTable GetGameTable(int id)
        {
            return _gameTableRepository.GetGameTable(id);
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table)
        {
            return _gameTableRepository.GetAvailableTableBoardGameList(table);
        }

        public IEnumerable<GameTable> GetAllGameTables()
        {
            return _gameTableRepository.GetAllGameTables();
        }

        public IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname)
        {
            return _gameTableRepository.GetAllGameTablesByGamerNickname(gamerNickname);
        }

        public void CreateGameTable(GameTable gameTable, List<int> tableBoardGameIdList)
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

        public void EditGameTable(GameTable gameTable)
        {
            _gameTableRepository.EditGameTable(gameTable);
        }

        public void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer)
        {
            foreach (var gameParticipation in gameParticipations)
            {
                var dbGameParticipation = _gameParticipationService.GetGameParticipation(gameParticipation.Id);
                if (dbGameParticipation != null)
                    _gameParticipationService.Edit(gameParticipation);
                else
                    _gameParticipationService.AddGameParticipation(gameParticipation);
            }

            _gameTableRepository.EditParticipations(gameParticipations, modifiedGamer);
        }

        public void DeleteGameTable(int id)
        {
            _gameTableRepository.DeleteGameTable(id);
        }
    }
}