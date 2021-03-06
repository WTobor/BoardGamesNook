﻿using System;
using System.Collections.Generic;
using BoardGamesNook.Validators;
using FluentValidation.Attributes;

namespace BoardGamesNook.ViewModels.GameTable
{
    [Validator(typeof(GameTableValidator))]
    public class GameTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedGamerId { get; set; }
        public string CreatedGamerNickname { get; set; }

        //TODO: allow multiple games
        public IEnumerable<TableBoardGameViewModel> TableBoardGameList { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }

        public string Street { get; set; }
    }
}