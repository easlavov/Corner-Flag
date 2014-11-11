using CornerFlag.SoccerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CornerFlag.Web.Controllers;
using XMLSoccerCOM;
using CornerFlag.Web.Models;

namespace CornerFlag.Web.Controllers
{
    public class LeagueController : BaseController
    {        
        public ActionResult All()
        {           
            //var leagues = MockedSoccerData.GetAllLeagues().OrderBy(x => x.Id).GroupBy(x => x.Country);
            var leaguesDemo = this.soccerData.GetAllLeagues().OrderBy(x => x.Id).GroupBy(x => x.Country);
            return View(leaguesDemo);
        }

        public ActionResult Details(int id)
        {
            // Fixtures per week - some control with paging
            // League standings per season - DONE!
            var model = new LeagueDetailsViewModel();
            model.League = this.soccerData.GetAllLeagues().First(l => l.Id == id);
            model.Standings = this.soccerData.GetLeagueStandingsBySeason(id.ToString(), 2014);
            return View(model);
        }

        public ActionResult Table(string id)
        {
            var currentYear = DateTime.Now.Year;
            var leagueStandings = this.soccerData.GetLeagueStandingsBySeason(id, currentYear);
            return PartialView("_Table", leagueStandings);
        }
    }
}