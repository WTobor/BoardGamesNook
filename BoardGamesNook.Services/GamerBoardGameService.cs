﻿using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using System.Collections.Generic;

namespace BoardGamesNook.Services
{
    public class GamerBoardGameService : IGamerBoardGameService
    {
        private readonly IGamerBoardGameRepository _gamerBoardGameRepository;

        public GamerBoardGameService(IGamerBoardGameRepository gamerBoardGameRepository)
        {
            _gamerBoardGameRepository = gamerBoardGameRepository;
        }

        public GamerBoardGame GetGamerBoardGame(int id)
        {
            return _gamerBoardGameRepository.GetGamerBoardGame(id);
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGames()
        {
            return _gamerBoardGameRepository.GetAllGamerBoardGames();
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNick(string gamerNick)
        {
            return _gamerBoardGameRepository.GetAllGamerBoardGamesByGamerNick(gamerNick);
        }

        public void Add(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.AddGamerBoardGame(gamerBoardGame);
        }

        public void Edit(GamerBoardGame gamerBoardGame)
        {
            _gamerBoardGameRepository.EditGamerBoardGame(gamerBoardGame);
        }

        public void DeleteGamerBoardGame(int id)
        {
            _gamerBoardGameRepository.DeleteGamerBoardGame(id);
        }
    }
}