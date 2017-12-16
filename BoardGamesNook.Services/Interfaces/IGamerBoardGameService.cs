﻿using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerBoardGameService
    {
        GamerBoardGame Get(int id);

        IEnumerable<GamerBoardGame> GetAll();

        IEnumerable<GamerBoardGame> GetAllByGamerNick(string gamerId);

        void Add(GamerBoardGame boardGame);

        void Edit(GamerBoardGame boardGame);

        void Delete(int id);
    }
}