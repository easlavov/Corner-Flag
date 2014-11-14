using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CornerFlag.Web.Controllers;
using CornerFlag.Web.Models;
using CornerFlag.Data.Models.Entities;
using CornerFlag.Data;

namespace CornerFlag.Web.Controllers
{
    public class TeamController : BaseController
    {
        public TeamController(ICornerFlagData data)
            : base(data)
        {

        }

        // TODO: Should default to Fixtures. GetTeam() unreliable!
        public ActionResult Details(string id)
        {
            
            return View();
        }

        public ActionResult Fixtures(string id)
        {
            
            return View();
        }

        public ActionResult Players(string id)
        {
            return View();
        }

        private void Test()
        {
            var countrye = new Country();
            
        }
    }
}