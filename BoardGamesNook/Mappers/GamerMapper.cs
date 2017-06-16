using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Mappers
{
    public class GamerMapper
    {
        public static IEnumerable<GamerViewModel> MapToGamerList(IEnumerable<Gamer> gamerList, string currentGamerId)
        {
            return gamerList.Select(x => MapToGamerViewModel(x, currentGamerId)).ToList();
        }

        public static GamerViewModel MapToGamerViewModel(Gamer gamer, string currentGamerId)
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
                    Street = gamer.Street,
                    IsCurrentGamer = currentGamerId == gamer.Id
                };
            }
        }
    }
}