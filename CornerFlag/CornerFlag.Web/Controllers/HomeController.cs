using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var team = this.SoccerData.GetTeam("Aberdeen");
            return View(team);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}