using System;

namespace BoardGamesNook.Model
{
    public class User
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }public bool IsConfirmed { get; set; }
        public bool Active { get; set; }
    }
}
