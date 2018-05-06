using System;
using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class GamerGenerator
    {
        public static Gamer Gamer1 = new Gamer
        {
            Id = Guid.Parse("11111111-2222-3333-4444-555555555555"),
            Active = true,
            Age = 25,
            Nickname = "programmer-girl",
            Name = "Weronika",
            Surname = "Tobor",
            City = "Wroc³aw",
            Street = "Testowa",
            Email = "wero15@op.pl"
        };

        public static Gamer Gamer2 = new Gamer
        {
            Id = Guid.Parse("22222222-3333-4444-5555-666666666666"),
            Active = true,
            Age = 19,
            Nickname = "tomek_K",
            Name = "Tomasz",
            Surname = "Kowalski",
            City = "Poznañ",
            Street = "Kamieñskiego",
            Email = "t.kowalski@gmail.com"
        };

        public static Gamer Gamer3 = new Gamer
        {
            Id = Guid.Parse("33333333-4444-5555-6666-777777777777"),
            Active = true,
            Age = 27,
            Nickname = "anna90",
            Name = "Anna",
            Surname = "Kowalska",
            City = "Gliwice",
            Street = "Buforowa",
            Email = "anna90@gmail.com"
        };

        public static Gamer Gamer4 = new Gamer
        {
            Id = Guid.Parse("44444444-5555-6666-7777-888888888888"),
            Active = true,
            Age = 34,
            Nickname = "macius",
            Name = "Maciej",
            Surname = "Nowak",
            City = "Warszawa",
            Street = "",
            Email = "nowak_maciej@onet.pl"
        };

        public static List<Gamer> Gamers = new List<Gamer>
        {
            Gamer1,
            Gamer2,
            Gamer3,
            Gamer4
        };
    }
}