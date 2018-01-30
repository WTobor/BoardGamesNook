using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Generators
{
    public class RelationsUpdateGenerator
    {
        public static void FillRelationsForBoardGameTable()
        {
            GameTableGenerator.GameTable1.GameParticipations = new List<GameParticipation>
            {
                GameParticipationGenerator.GameParticipation1,
                GameParticipationGenerator.GameParticipation2
            };

            GameTableGenerator.GameTable2.GameParticipations = new List<GameParticipation>
            {
                GameParticipationGenerator.GameParticipation3
            };
        }
    }
}