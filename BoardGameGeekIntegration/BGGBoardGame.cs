using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using BoardGameGeekIntegration.Models;
using BoardGamesNook.Model;
using Newtonsoft.Json;

namespace BoardGameGeekIntegration
{
    public static class BGGBoardGame
    {
        public static int GetBoardGameId(string name)
        {
            var objectId = 0;

            var url = string.Format(Constants.getXMLBoardGameObjectByName, name);
            var BGGBoardGameObjectStr = GetStringResponse(url);
            object boardGamesObject = new boardgames();

            var xmlSerializer = new XmlSerializer(typeof(boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameObjectStr))
            {
                boardGamesObject = xmlSerializer.Deserialize(textReader);
            }

            var boardGames = (boardgames) boardGamesObject;

            if (boardGames.boardgame != null && boardGames.boardgame.Length > 0)
                objectId = (int) boardGames.boardgame.First().objectid;

            return objectId;
        }

        public static IEnumerable<SimilarBoardGame> GetSimilarBoardGameList(string name)
        {
            var url = string.Format(Constants.getXMLBoardGameObjectListByName, name);
            var BGGBoardGameObjectStr = GetStringResponse(url);
            object boardGamesObject = new boardgames();

            var xmlSerializer = new XmlSerializer(typeof(boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameObjectStr))
            {
                boardGamesObject = xmlSerializer.Deserialize(textReader);
            }

            var boardGames = (boardgames) boardGamesObject;

            if (boardGames.boardgame != null && boardGames.boardgame.Length > 0)
                return boardGames.boardgame.Select(x => new SimilarBoardGame
                {
                    Id = (int) x.objectid,
                    Name = x.name.Value
                }).ToList();

            return null;
        }


        public static BoardGame GetBoardGameById(int id)
        {

            var url = string.Format(Constants.getJSONBoardGameObjectDetailsById, id);
            var BGGBoardGameObjectDetailsStr = GetStringResponse(url);

            var boardGameDetails = JsonConvert.DeserializeObject<BoardGameDetails>(BGGBoardGameObjectDetailsStr);

            var boardGame = new BoardGame
            {
                Name = boardGameDetails.name,
                Description = boardGameDetails.description,
                MinPlayers = boardGameDetails.minPlayers,
                MaxPlayers = boardGameDetails.maxPlayers,
                MaxTime = boardGameDetails.playingTime,
                BGGId = id,
                IsExpansion = boardGameDetails.isExpansion,
                ImageUrl = boardGameDetails.thumbnail,
                CreatedDate = DateTimeOffset.Now
            };

            return boardGame;
        }

        public static string GetStringResponse(string url)
        {
            var result = string.Empty;
            var request = WebRequest.Create(url);
            request.ContentType = "text/javascript";
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                var reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
            }

            response.Close();
            return result;
        }
    }
}