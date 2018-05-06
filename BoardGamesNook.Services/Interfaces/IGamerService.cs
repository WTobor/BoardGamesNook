using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer GetGamer(Guid id);

        Gamer GetGamerByEmail(string userEmail);

        Gamer GetGamerBoardGameByNickname(string userNickname);

        bool NicknameExists(string nickname);

        IEnumerable<Gamer> GetAllGamers();

        void AddGamer(Gamer gamer);

        void EditGamer(Gamer gamer);

        void DeactivateGamer(Guid id);
    }
}