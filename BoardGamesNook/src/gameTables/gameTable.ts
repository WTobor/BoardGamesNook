import { TableBoardGame } from "./tableBoardGame";

export class GameTable {
    Id: number;
    Name: string;
    GamerId: string;
    GamerNick: string;
    TableBoardGameList: TableBoardGame[];
    MinPlayers: number;
    MaxPlayers: number;
    City: string;
    Street: string;
    IsPrivate: boolean;
    CreatedDate: Date;
}