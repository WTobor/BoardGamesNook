namespace BoardGamesNook.Model
{
    public class UserGamer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GamerId { get; set; }
        public Gamer Gamer { get; set; }
    }
}
