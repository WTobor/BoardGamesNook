﻿using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameTableRepository : IGameTableRepository
    {
        private readonly BoardGameRepository _boardGameRepository = new BoardGameRepository();
        private readonly GamerRepository _gamerRepository = new GamerRepository();
        private readonly List<GameTable> _gameTables = GameTableGenerator.GameTables;

        public GameTable Get(int id)
        {
            return _gameTables.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameTable> GetAllGameTables()
        {
            return _gameTables;
        }

        public IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table)
        {
            var availableTableBoardGameList = _boardGameRepository.GetAll();
            if (table?.BoardGames != null)
                availableTableBoardGameList =
                    availableTableBoardGameList.Where(x => !table.BoardGames.Contains(x)).ToList();
            return availableTableBoardGameList;
        }

        public IEnumerable<GameTable> GetAllGameTablesByGamerNickname(string gamerNickname)
        {
            //temporaty solution, when no users
            var gamer = _gamerRepository.GetByNickname(gamerNickname);
            if (gamer != null)
            {
                return _gameTables.Where(x => x.CreatedGamerId == gamer.Id).ToList();
            }
            return new List<GameTable>();
        }

        public void AddGameTable(GameTable gameTable)
        {
            var id = _gameTables.Max(x => x.Id) + 1;
            gameTable.Id = id;
            _gameTables.Add(gameTable);
        }

        public void EditGameTable(GameTable gameTable)
        {
            gameTable.ModifiedDate = DateTimeOffset.Now;
        }

        public void EditGameTableParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer)
        {
            var gameTableId = gameParticipations.Select(x => x.GameTableId).FirstOrDefault();
            var dbGameTable = Get(gameTableId);
            if (dbGameTable != null)
            {
                dbGameTable.GameParticipations = gameParticipations;
                dbGameTable.ModifiedGamerId = modifiedGamer.Id;
                dbGameTable.ModifiedGamer = modifiedGamer;
                dbGameTable.ModifiedDate = DateTimeOffset.Now;
            }
        }

        public void Deactivate(int id)
        {
            var gameTable = _gameTables.FirstOrDefault(x => x.Id == id);
            if (gameTable != null)
            {
                gameTable.Active = false;
                gameTable.ModifiedDate = DateTimeOffset.Now;
            }
        }
    }
}