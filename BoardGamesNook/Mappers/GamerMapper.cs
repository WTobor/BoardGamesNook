using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Mappers
{
    public class GamerMapper
    {
        public static IEnumerable<GamerViewModel> MapToGamerList(IEnumerable<Gamer> gamerList)
        {
            return gamerList.Select(x => MapToGamerViewModel(x)).ToList();
        }

        public static GamerViewModel MapToGamerViewModel(Gamer gamer)
        {
            if (gamer == null)
            {
                return null;
            }
            else
            {
                return new GamerViewModel()
                {
                    Id = gamer.Id.ToString(),
                    Nick = gamer.Nick,
                    Name = gamer.Name,
                    Surname = gamer.Surname,
                    Email = gamer.Email,
                    Age = gamer.Age,
                    City = gamer.City,
                    Street = gamer.Street
                };
            }
        }
    }
}