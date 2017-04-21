
using System;

namespace BoardGamesNook.Model
{
    public class BoardGame
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int? BGGId { get; set; }
        public bool IsExpansion { get; set; }
        public int? ParentId { get; set; }
        public bool IsConfirmed { get; set; }
        public bool Active { get; set; }
        public string ImageUrl { get; set; }

    public virtual BoardGame ParentBoardGame { get; set; }
    }
}
