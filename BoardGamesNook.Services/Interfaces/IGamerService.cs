using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer Get(int id);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Delete(int id);
    }
}