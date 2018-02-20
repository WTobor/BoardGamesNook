using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Objects
{
    public class BoardGameObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public string BGGUrl { get; set; }
        public bool IsExpansion { get; set; }
        public int? ParentId { get; set; }
        public virtual BoardGame ParentBoardGame { get; set; }
    }
}