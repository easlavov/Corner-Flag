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
    public class CompetitionsController : BaseController
    {
        public CompetitionsController(ICornerFlagData data)
            : base(data)
        {
        }

        public ActionResult All()
        {       
            var competitions = this.data.Competitions.All();
            return View(competitions);
        }

        public ActionResult Details(int id)
        {
            var competition = this.data.Competitions.GetById(id);
            return View(competition);
        }
    }
}