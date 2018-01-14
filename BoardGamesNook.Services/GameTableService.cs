using System.Collections.Generic;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GameTableService : IGameTableService
    {
        private readonly IGameTableRepository _gameTableRepository;

        public GameTableService(IGameTableRepository gameTableRepository)
        {
            _gameTableRepository = gameTableRepository;
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

        public IEnumerable<GameTable> GetAllGameTablesByGamerNick(string gamerNick)
        {
            return _gameTableRepository.GetAllGameTablesByGamerNick(gamerNick);
        }

        public void AddGameTable(GameTable gameTable)
        {
            _gameTableRepository.AddGameTable(gameTable);
        }

        public void EditGameTable(GameTable gameTable)
        {
            _gameTableRepository.EditGameTable(gameTable);
        }

        public void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer)
        {
            _gameTableRepository.EditParticipations(gameParticipations, modifiedGamer);
        }

        public void DeleteGameTable(int id)
        {
            _gameTableRepository.DeleteGameTable(id);
        }
    }
}