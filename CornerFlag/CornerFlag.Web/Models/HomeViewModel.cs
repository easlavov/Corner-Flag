using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSoccerCOM;

namespace CornerFlag.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            TopLeagues = new List<IList<TeamLeagueStanding>>();
        }

        public IEnumerable<IGrouping<string, Match>> TodayFixtures { get; set; }

        public IList<IList<TeamLeagueStanding>> TopLeagues { get; set; }
    }
}