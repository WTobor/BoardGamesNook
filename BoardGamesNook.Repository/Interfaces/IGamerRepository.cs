using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerRepository
    {
        Gamer Get(Guid id);

        Gamer GetByEmail(string userEmail);

        Gamer GetByNickname(string userNickname);

        bool NicknameExists(string nickname);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Deactivate(Guid id);
    }
}