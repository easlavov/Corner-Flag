using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CornerFlag.Web.Controllers;
using CornerFlag.Web.Models;

namespace CornerFlag.Web.Controllers
{
    public class TeamController : BaseController
    {
        // TODO: Should default to Fixtures. GetTeam() unreliable!
        public ActionResult Details(string id)
        {
            var team = this.soccerData.GetTeam(id);
            return View("TeamView", team);
        }

        public ActionResult Fixtures(string id)
        {
            // Getting last years fixtures to ensure a populated list
            var to = DateTime.Now;
            var from = to.AddYears(-1);
            var fixtures = this.soccerData
                               .GetFixturesByDateIntervalAndTeam(from, to, id);
            var model = new FixturesViewModel
            {
                TeamName = id,
                Fixtures = fixtures
            };
            return View(model);
        }

        public ActionResult Players(string id)
        {
            var model = new TeamPlayersViewModel();
            model.TeamName = id;
            model.Players = this.soccerData.GetPlayersById(id);
            return View(model);
        }
    }
}