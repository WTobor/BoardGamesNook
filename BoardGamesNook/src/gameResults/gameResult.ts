export class GameResult {
    Id: number;
    CreatedGamerId: string;
    CreatedGamerNickname: string;
    GamerId: string;
    GamerNickname: string;
    BoardGameId: number;
    BoardGameName: string;
    Points: number | null;
    Place: number | null;
    PlayersNumber: number;
    GameTableId: number | null;
    GameTableName: string;
}