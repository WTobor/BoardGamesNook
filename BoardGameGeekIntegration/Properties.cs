using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using BoardGamesNook.Model;

namespace BoardGameGeekIntegration
{
    public static class Properties
    {
        public static BoardGame GetBoardGameProperties(string BGGBoardGameStr)
        {
            BoardGame boardGame = new BoardGame();
            object boardGamesObject = new Models.boardgames();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.boardgames));
            using (TextReader textReader = new StringReader(BGGBoardGameStr))
            {
                boardGamesObject = xmlSerializer.Deserialize(textReader);
            }
                

            Type boardGameObjectType = boardGamesObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(boardGameObjectType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "boardgame")
                {
                    
                }
            }

            return boardGame;
        }
    }
}
