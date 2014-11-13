﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models.Entities;
using CornerFlag.Data.Models.People;

namespace CornerFlag.Data.Models
{
    public class Match : DatabaseEntity
    {
        public Match()
        {
            this.HomeTeam = new HashSet<Player>();
            this.AwayTeam = new HashSet<Player>();
        }

        public DateTime Date { get; set; }

        public int HomeClubId { get; set; }

        public virtual Club HomeClub { get; set; }

        public virtual ICollection<Player> HomeTeam { get; set; }

        public int AwayClubId { get; set; }

        public virtual Club AwayClub { get; set; }
        
        public virtual ICollection<Player> AwayTeam { get; set; }

        public virtual Stadium Venue { get; set; }

        public virtual Season Season { get; set; }

        public virtual Competition Competition { get; set; }

        public int HomeGoalsScored { get; set; }

        public int AwayGoalsScored { get; set; }

        public Result GetResult()
        {
            int goalsDifference = this.HomeGoalsScored - this.AwayGoalsScored;
            if (goalsDifference < 0)
            {
                return Result.AwayTeamVictory;
            }
            else if (goalsDifference > 0)
            {
                return Result.HomeTeamVictory;
            }

            return Result.Draw;
        }
    }
}
