using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers.Teams
{
    public class TeamController : BaseController
    {
        public ActionResult Details(string id)
        {
            var team = this.soccerData.GetTeam(id);
            return View("TeamView", team);
        }
    }
}