
namespace BoardGameGeekIntegration
{
    public static class Constants
    {
        public const string BGGApiUrl = @"https://boardgamegeek.com/xmlapi/";
        public const string getBoardGameObject = BGGApiUrl + @"search?search={0}";
    }
}
