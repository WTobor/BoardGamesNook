namespace BoardGamesNook.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public int GenderType { get; set; }
        public bool Confirmed { get; set; }
    }
}