using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerRepository
    {
        Gamer Get(int id);

        Gamer GetByEmail(string userEmail);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Delete(int id);
    }
}