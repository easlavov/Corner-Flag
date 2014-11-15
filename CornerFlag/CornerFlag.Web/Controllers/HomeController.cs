namespace CornerFlag.Web.Controllers
{
    using CornerFlag.Data;
    using CornerFlag.SoccerData;
    using CornerFlag.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI;
    using XMLSoccerCOM;

    public class HomeController : BaseController
    {
        public HomeController(ICornerFlagData data)
            : base(data)
        {

        }

        [HttpGet]        
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.Competitions = this.data.Competitions.All();
            homeViewModel.Clubs = this.data.Clubs.All();
            homeViewModel.Teams = this.data.Teams.All();

            return View(homeViewModel);
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