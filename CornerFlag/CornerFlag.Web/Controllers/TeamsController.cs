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
    public class TeamsController : BaseController
    {
        public TeamsController(ICornerFlagData data)
            : base(data)
        {

        }

        public ActionResult All()
        {
            var teams = this.data.Teams.All();
            return View(teams);
        }

        public ActionResult Details(int id)
        {
            var teams = this.data.Teams.GetById(id);
            return View(teams);
        }
    }
}