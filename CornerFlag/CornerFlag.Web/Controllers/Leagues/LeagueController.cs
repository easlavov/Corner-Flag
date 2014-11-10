using CornerFlag.SoccerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMLSoccerCOM;

namespace CornerFlag.Web.Controllers.Leagues
{
    public class LeagueController : BaseController
    {        
        public ActionResult All()
        {           
            var leagues = MockedSoccerData.GetAllLeagues().OrderBy(x => x.Id).GroupBy(x => x.Country);
            return View(leagues);
        }

        public ActionResult Details(string id)
        {
            // Fixtures per week - some control with paging
            // League standings per season - DONE!

            return View(id as object);
        }

        public ActionResult Table(string id)
        {
            var currentYear = DateTime.Now.Year;
            var leagueStandings = this.soccerData.GetLeagueStandingsBySeason(id, currentYear);
            return PartialView("_Table", leagueStandings);
        }
    }
}