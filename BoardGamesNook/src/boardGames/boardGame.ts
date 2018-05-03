export class BoardGame {
    Id: number;
    Name: string;
    Description: string;
    MinPlayers: number;
    MaxPlayers: number;
    MinAge: number;
    MinTime: TimeRanges;
    MaxTime: TimeRanges;
    BGGId: number | null;
    IsExpansion: boolean;
    ParentId: number | null;
    ParentBoardGame: BoardGame | null;
    ImageUrl: string;
}