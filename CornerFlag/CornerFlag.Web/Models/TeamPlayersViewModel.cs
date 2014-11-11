using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSoccerCOM;

namespace CornerFlag.Web.Models
{
    public class TeamPlayersViewModel
    {
        public Team Team { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}