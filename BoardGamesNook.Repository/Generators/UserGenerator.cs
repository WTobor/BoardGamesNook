using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class UserGenerator
    {
        public static User user1 = new User()
        {
            Id = 1,
            Login = "test1",
            Password = "test1",
            Active = true
        };

        public static User user2 = new User()
        {
            Id = 2,
            Active = true,
            Login = "test2",
            Password = "test2",
        };

        public static List<User> users = new List<User>()
        {
            user1,
            user2
        };
    }
}
