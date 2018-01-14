using System;

namespace BoardGamesNook.Model
{
    public class Gamer
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
    }
}