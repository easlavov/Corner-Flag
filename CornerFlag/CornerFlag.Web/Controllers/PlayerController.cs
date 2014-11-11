using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class PlayerController : BaseController
    {
        public ActionResult Details(int id)
        {
            var player = this.soccerData.GetPlayerById(id);
            return View(player);
        }
    }
}