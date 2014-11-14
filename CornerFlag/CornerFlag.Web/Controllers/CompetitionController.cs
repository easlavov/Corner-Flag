using CornerFlag.SoccerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CornerFlag.Web.Controllers;
using XMLSoccerCOM;
using CornerFlag.Web.Models;
using CornerFlag.Data;

namespace CornerFlag.Web.Controllers
{
    public class CompetitionController : BaseController
    {
        public CompetitionController(ICornerFlagData data)
            : base(data)
        {
        }

        public ActionResult All()
        {       
            var comps = this.data.Competitions.All();
            return View(comps);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Table(string id)
        {
            return PartialView();
        }
    }
}