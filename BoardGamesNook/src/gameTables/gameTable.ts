import { TableBoardGame } from "./tableBoardGame";

export class GameTable {
    Id: number;
    GamerId: number;
    GamerNick: string;
    TableBoardGameList: TableBoardGame[];
    MinPlayers: number;
    MaxPlayers: number;
    City: string;
    Street: string;
    IsPrivate: boolean;
    CreatedDate: Date;
}