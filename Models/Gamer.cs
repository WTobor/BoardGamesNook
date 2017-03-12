using System;

namespace BoardGamesNook.Models
{
    public class Gamer
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Active { get; set; }
    }
}
