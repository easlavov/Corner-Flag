using CornerFlag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class ClubsController : BaseController
    {
        public ClubsController(ICornerFlagData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var clubs = this.data.Clubs.All();
            return View(clubs);
        }

        public ActionResult Details(int id)
        {
            var club = this.data.Clubs.GetById(id);
            return View(club);
        }
    }
}