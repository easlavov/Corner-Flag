namespace CornerFlag.Web.Controllers
{
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
        [HttpGet]        
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.TodayFixtures = this.soccerData.GetLiveScoreByLeague(null).OrderByDescending(m => m.Date).GroupBy(m => m.League);
            //homeViewModel.TodayFixtures = MockedSoccerData.MatchListRandom().OrderByDescending(m => m.Date).GroupBy(m => m.League);
            //homeViewModel.TodayFixtures = this.soccerData.GetLiveScoreByLeague(null).OrderByDescending(m => m.Date).GroupBy(m => m.League);
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());
            //homeViewModel.TopLeagues.Add(MockedSoccerData.LeagueStandingRandom().OrderByDescending(x => x.Points).ToList());

            homeViewModel.TopLeagues.Add(this.soccerData.GetLeagueStandingsBySeason("3", 2014));

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