
namespace BoardGameGeekIntegration
{
    public static class Constants
    {
        public const string BGGXMLApiUrl = @"https://boardgamegeek.com/xmlapi/";
        public const string BGGJSONApiUrl = @"https://bgg-json.azurewebsites.net/";
        public const string getXMLBoardGameObjectListByName = BGGXMLApiUrl + @"search?search={0}";
        public const string getXMLBoardGameObjectByName = BGGXMLApiUrl + @"search?search={0}&exact=1";
        public const string getJSONBoardGameObjectDetailsById = BGGJSONApiUrl + @"thing/{0}";
    }
}
