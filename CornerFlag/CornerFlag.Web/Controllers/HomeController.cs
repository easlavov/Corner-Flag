namespace CornerFlag.Web.Controllers
{
    using CornerFlag.SoccerData;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI;

    public class HomeController : BaseController
    {
        [HttpGet]        
        public ActionResult Index()
        {
            //var leagues = this.SoccerData.GetAllLeagues();
            // TODO: Dependency inversion
            var liveScores = this.soccerData.GetLiveScoreByLeague(null);
            
            //var viewModel = new HomeViewModel
            //{
            //    TodayFixtures = todayMatches,
            //    Leagues = leagues
            //};
            return View(liveScores);
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