﻿using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Generators;
using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Repository
{
    public class GameTableRepository : IGameTableRepository
    {
        private List<GameTable> _gameTables = GameTableGenerator.gameTables;

        public GameTable Get(int id)
        {
            return _gameTables.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<GameTable> GetAll()
        {
            return _gameTables;
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