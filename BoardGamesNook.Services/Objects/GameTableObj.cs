using System;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Objects
{
    public class GameTableObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedGamerId { get; set; }
        public string CreatedGamerNickname { get; set; }
        public IEnumerable<TableBoardGameObj> TableBoardGameList { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}