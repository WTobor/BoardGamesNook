
namespace BoardGameGeekIntegration
{

    public class BoardGameDetails
    {
        public int gameId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public int playingTime { get; set; }
        public string[] mechanics { get; set; }
        public bool isExpansion { get; set; }
        public int yearPublished { get; set; }
        public float bggRating { get; set; }
        public float averageRating { get; set; }
        public int rank { get; set; }
        public string[] designers { get; set; }
        public string[] publishers { get; set; }
        public string[] artists { get; set; }
        public Playerpollresult[] playerPollResults { get; set; }
        public Expansion[] expansions { get; set; }
    }

    public class Playerpollresult
    {
        public int numPlayers { get; set; }
        public int best { get; set; }
        public int recommended { get; set; }
        public int notRecommended { get; set; }
        public bool numPlayersIsAndHigher { get; set; }
    }

    public class Expansion
    {
        public string name { get; set; }
        public int gameId { get; set; }
    }

}
