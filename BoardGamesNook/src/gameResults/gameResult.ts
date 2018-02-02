export class GameResult {
    Id: number;
    GamerId: string;
    GamerNickname: string;
    CreatedGamerId: string;
    CreatedGamerNickname: string;
    BoardGameId: number;
    BoardGameName: string;
    Points: number | null;
    Place: number | null;
    PlayersNumber: number;
    Active: boolean;
}