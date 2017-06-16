using System;

namespace BoardGamesNook.Model
{
    public class GameParticipation
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedGamerId { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public string ModifiedGamerId { get; set; }
        public int GameTableId { get; set; }
        public GameTable GameTable { get; set; }
        public string GamerId { get; set; }
        public Gamer Gamer { get; set; }
        public bool IsConfirmed { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
    }
}