using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSoccerCOM;

namespace CornerFlag.Web.Models
{
    public class FixturesViewModel
    {
        public string TeamName { get; set; }

        public IQueryable<Match> Fixtures { get; set; }
    }
}