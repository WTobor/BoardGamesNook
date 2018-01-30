import { TableBoardGame } from "./tableBoardGame";
import {Gamer} from "../gamers/gamer";

export class GameTable {
    Id: number;
    Name: string;
    CreatedGamerId: string;
    CreatedGamerNickname: string;
    TableBoardGameList: TableBoardGame[];
    /*TableGamerList: Gamer[];*/
    MinPlayers: number;
    MaxPlayers: number;
    City: string;
    Street: string;
    IsPrivate: boolean;
    CreatedDate: Date;
}