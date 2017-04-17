
namespace BoardGameGeekIntegration
{
    public static class Constants
    {
        public const string BGGApiUrl = @"https://boardgamegeek.com/xmlapi/";
        public const string getBoardGameObjectByName = BGGApiUrl + @"search?search={0}";
        public const string getBoardGameObjectDetailsById = BGGApiUrl + @"boardgame/{0}";
    }
}
