using CornerFlag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController(ICornerFlagData data)
            : base(data)
        {

        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}