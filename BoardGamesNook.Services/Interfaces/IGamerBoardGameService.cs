﻿using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerBoardGameService
    {
        GamerBoardGame GetGamerBoardGame(int id);

        IEnumerable<GamerBoardGame> GetAllGamerBoardGames();

        IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname);

        void Add(GamerBoardGame boardGame);

        void Edit(GamerBoardGame boardGame);

        void DeleteGamerBoardGame(int id);
    }
}