using System;
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

        private BoardGameRepository _boardGameRepository = new BoardGameRepository();

        public GameTable GetGameTable(int id)
        {
            return _gameTables.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameTable> GetAllGameTables()
        {
            return _gameTables;
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table)
        {
            var availableTableBoardGameList = _boardGameRepository.GetAllGamerBoardGames();
            if (table != null && table.BoardGames != null)
            {
                availableTableBoardGameList = availableTableBoardGameList.Where(x => !table.BoardGames.Contains(x)).ToList();
            }
            return availableTableBoardGameList;
        }

        public IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname)
        {
            //temporaty solution, when no users
            return _gameTables.Where(x => x.CreatedGamer.Nickname == gamerNickname).ToList();
        }

        public void AddGameTable(GameTable gameTable)
        {
            _gameTables.Add(gameTable);
        }

        public void EditGameTable(GameTable gameTable)
        {
            var oldGameTable = _gameTables.FirstOrDefault(x => x.Id == gameTable.Id);
            if (oldGameTable != null)
            {
                _gameTables.Remove(oldGameTable);
                _gameTables.Add(gameTable);
            }
        }

        public void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer)
        {
            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = GetGameTable(gameTableId);
            if (dbGameTable != null)
            {
                dbGameTable.GameParticipations = gameParticipations;
                dbGameTable.ModifiedGamerId = modifiedGamer.Id;
                dbGameTable.ModifiedGamer = modifiedGamer;
                dbGameTable.ModifiedDate = DateTimeOffset.Now;
            }
        }

        public void DeleteGameTable(int id)
        {
            var gameTable = _gameTables.FirstOrDefault(x => x.Id == id);
            if (gameTable != null)
            {
                _gameTables.Remove(gameTable);
            }
        }
    }
}