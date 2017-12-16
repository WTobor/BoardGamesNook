using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class RelationsUpdateGenerator
    {
        public static void FillRelationsForBoardGameTable()
        {
            GameTableGenerator.gameTable1.GameParticipations = new List<GameParticipation>
            {
                GameParticipationGenerator.gameParticipation1,
                GameParticipationGenerator.gameParticipation2
            };

            GameTableGenerator.gameTable2.GameParticipations = new List<GameParticipation>
            {
                GameParticipationGenerator.gameParticipation3
            };
        }
    }
}