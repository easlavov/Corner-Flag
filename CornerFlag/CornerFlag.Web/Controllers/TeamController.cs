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
            return View();
        }

        public ActionResult Players(string id)
        {
            var model = new TeamPlayersViewModel();
            model.Team = this.soccerData.GetTeam(id);
            model.Players = this.soccerData.GetPlayersById(id);
            return View(model);
        }
    }
}