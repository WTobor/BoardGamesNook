using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class GamerGenerator
    {
        public static Gamer gamer1 = new Gamer
        {
            Id = "a1s2d3f4",
            Active = true,
            Age = 25,
            Nickname = "programmer-girl",
            Name = "Weronika",
            Surname = "Tobor",
            City = "Wroc³aw",
            Street = "Testowa",
            Email = "wero15@op.pl"
        };

        public static Gamer gamer2 = new Gamer
        {
            Id = "q1w2e3r4",
            Active = true,
            Age = 19,
            Nickname = "tomek_K",
            Name = "Tomasz",
            Surname = "Kowalski",
            City = "Poznañ",
            Street = "Kamieñskiego",
            Email = "t.kowalski@gmail.com"
        };

        public static Gamer gamer3 = new Gamer
        {
            Id = "z2x3c4v5",
            Active = true,
            Age = 27,
            Nickname = "anna90",
            Name = "Anna",
            Surname = "Kowalska",
            City = "Gliwice",
            Street = "Buforowa",
            Email = "anna90@gmail.com"
        };

        public static Gamer gamer4 = new Gamer
        {
            Id = "n7m8k9l0",
            Active = true,
            Age = 34,
            Nickname = "macius",
            Name = "Maciej",
            Surname = "Nowak",
            City = "Warszawa",
            Street = "",
            Email = "nowak_maciej@onet.pl"
        };

        public static List<Gamer> gamers = new List<Gamer>
        {
            gamer1,
            gamer2,
            gamer3,
            gamer4
        };
    }
}