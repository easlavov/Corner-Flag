using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSoccerCOM;

namespace CornerFlag.Web.Models
{
    public class LeagueDetailsViewModel
    {
        public League League { get; set; }

        public IEnumerable<TeamLeagueStanding> Standings { get; set; }
    }
}