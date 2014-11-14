using CornerFlag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(ICornerFlagData data)
            : base(data)
        {

        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}