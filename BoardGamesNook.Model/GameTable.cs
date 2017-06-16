using System;
using System.Collections.Generic;

namespace BoardGamesNook.Model
{
    public class GameTable
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedGamerId { get; set; }
        public Gamer CreatedGamer { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public string ModifiedGamerId { get; set; }
        public Gamer ModifiedGamer { get; set; }
        public int MinPlayersNumber { get; set; }
        public int MaxPlayersNumber { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsFull { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Active { get; set; }
        public List<BoardGame> BoardGames { get; set; }
        public List<GameParticipation> GameParticipationInfo { get; set; }
    }
}