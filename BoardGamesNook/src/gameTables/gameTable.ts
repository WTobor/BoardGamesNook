import {TableBoardGame} from "./tableBoardGame";

export class GameTable {
    Id: number;
    GamerId: number;
    GamerNick: string;
    TableBoardGameList: TableBoardGame[];
    PlayersNumber: number;
    City: string;
    Street: string;
    IsPrivate: boolean;
    CreatedDate: Date;
}