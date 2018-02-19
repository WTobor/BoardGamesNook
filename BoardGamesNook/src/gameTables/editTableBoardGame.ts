export class EditTableBoardGame {
    Id: number;
    TableBoardGameIdList: number[];

    constructor(id: number, tableBoardGameIdList: number[]) {
        this.Id = id;
        this.TableBoardGameIdList = tableBoardGameIdList;
    }
}