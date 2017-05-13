using System;

namespace BoardGamesNook.ViewModels.GameTable
{
    public class GameTableViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public int PlayersNumber { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsFull { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Active { get; set; }
        //public List<GameParticipation> GameParticipationInfo { get; set; }
    }
}