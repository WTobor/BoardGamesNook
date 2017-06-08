using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class GamerGenerator
    {
        public static Gamer gamer1 = new Gamer()
        {
            Id = 1,
            Active = true,
            Age = 5,
            Nick = "testNick",
            Name = "testName",
            Surname = "testSurname",
            City = "Wroc�aw",
            Street = "tmp",
            Email = "test1@test.pl"
        };

        public static Gamer gamer2 = new Gamer()
        {
            Id = 2,
            Active = true,
            Age = 51,
            Nick = "testNick1",
            Name = "testName1",
            Surname = "testSurname1",
            City = "Wroc�aw1",
            Street = "tmp1",
            Email = "test2@test.pl"
        };

        public static List<Gamer> gamers = new List<Gamer>()
        {
            gamer1,
            gamer2
        };
    }
}