using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSoccerCOM;

namespace CornerFlag.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Match> TodayFixtures { get; set; }

        public IEnumerable<League> Leagues { get; set; }
    }
}