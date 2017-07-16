using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameTableRepository : IGameTableRepository
    {
        private List<GameTable> _gameTables = GameTableGenerator.gameTables;

        private BoardGameRepository boardGameRepository = new BoardGameRepository();

        public GameTable Get(int id)
        {
            return _gameTables.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<GameTable> GetAll()
        {
            return _gameTables;
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table)
        {
            var availableTableBoardGameList = boardGameRepository.GetAll();
            if (table != null && table.BoardGames != null)
            {
                availableTableBoardGameList = availableTableBoardGameList.Where(x => !table.BoardGames.Contains(x)).ToList();
            }
            return availableTableBoardGameList;
        }

        public IEnumerable<GameTable> GetAllByGamerNick(string gamerNick)
        {
            //temporaty solution, when no users
            return _gameTables.Where(x => x.CreatedGamer.Nick == gamerNick).ToList();
        }

        public void Add(GameTable gameTable)
        {
            _gameTables.Add(gameTable);
        }

        public void Edit(GameTable gameTable)
        {
            var oldGameTable = _gameTables.Where(x => x.Id == gameTable.Id).FirstOrDefault();
            if (oldGameTable != null)
            {
                _gameTables.Remove(oldGameTable);
                _gameTables.Add(gameTable);
            }
        }

        public void EditParticipations(List<GameParticipation> gameParticipations)
        {
            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = Get(gameTableId);
            if (dbGameTable != null)
            {
                dbGameTable.GameParticipations = gameParticipations;
            }
        }

        public void Delete(int id)
        {
            var gameTable = _gameTables.Where(x => x.Id == id).FirstOrDefault();
            if (gameTable != null)
            {
                _gameTables.Remove(gameTable);
            }
        }
    }
}