namespace CornerFlag.SoccerData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Caching;
    using XMLSoccerCOM;

    public class CachedSoccerData
    {
        private const string XML_SOCCER_API_KEY =
            "PWGWJJKBSTZMDKKYTCEGKKGCFVVVTZEJVWSHAFVXBWJLOOVBGA";
        private  Requester requester;

        // Time intervals in seconds
        private const int SHORT_TIME_INTERVAL = 25;
        private const int MEDIUM_TIME_INTERVAL = 300;
        private const int BIG_TIME_INTERVAL = 3600;

        public CachedSoccerData()
        {
            requester = new Requester(XML_SOCCER_API_KEY, true);            
        }

        //GetLiveScore: 25 seconds
        //GetLiveScoreByLeague: 25 seconds
        /// <summary>
        /// Returns a list of matches by league name or all matches if null.
        /// </summary>
        /// <param name="league">The league to get lives scores for.</param>
        /// <returns>The list of matches</returns>
        public IList<Match> GetLiveScoreByLeague(string league)
        {
            string key = MethodBase.GetCurrentMethod().Name + league;
            if (HttpContext.Current.Cache[key] == null)
            {
                IList<Match> info;
                if (string.IsNullOrEmpty(league))
                {
                    info = requester.GetLiveScore();
                }
                else
                {
                    info = requester.GetLiveScoreByLeague(league);
                }

                AddToCache(key, info, SHORT_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        //GetOddsByFixtureMatchID: 3600 seconds

        //GetHistoricMatchesByLeagueAndSeason: 3600 seconds
        public IList<Match> GetHostoricMatchesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                IList<Match> info;
                info = requester.GetHistoricMatchesByLeagueAndSeason(league, seasonStartYear);

                AddToCache(key, info, BIG_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        //GetAllTeams/GetAllTeamsByLeagueAndSeason: 3600 seconds
        /// <summary>
        /// Retruns a list of teams by league name and season start year or all if league is null.
        /// </summary>
        /// <param name="league">The name of the league. Set null if you want all teams returned.</param>
        /// <param name="seasonStartYear">The season start year.</param>
        /// <returns>A list of teams.</returns>
        public IList<Team> GetAllTeamsByLeagueAndSeason(string league, int seasonStartYear = 0)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                IList<Team> info;
                if (string.IsNullOrEmpty(league))
                {
                    info = requester.GetAllTeams();
                }
                else
                {
                    info = requester.GetAllTeamsByLeagueAndSeason(league, seasonStartYear);
                }

                AddToCache(key, info, BIG_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Team>;
        }

        //GetAllLeagues: 3600 seconds
        public IList<League> GetAllLeagues()
        {
            string key = MethodBase.GetCurrentMethod().Name;
            if (HttpContext.Current.Cache[key] == null)
            {
                IList<League> info;
                info = requester.GetAllLeagues();

                AddToCache(key, info, BIG_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<League>;
        }

        //All others: 300 seconds
        public IList<Group> GetAllGroupsByLeagueAndSeason(string league, int seasonStartYear = 0)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetAllGroupsByLeagueAndSeason(league, seasonStartYear);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Group>;
        }

        public IList<TeamLeagueStanding> GetCupStandingsByGroupId(int groupId)
        {
            string key = MethodBase.GetCurrentMethod().Name + groupId;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetCupStandingsByGroupId(groupId);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<TeamLeagueStanding>;
        }

        public IList<Match> GetFixturesByDateInterval(DateTime from, DateTime to)
        {
            string key = MethodBase.GetCurrentMethod().Name + from.ToShortDateString() + to.ToShortDateString();
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetFixturesByDateInterval(from, to);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        public IList<Match> GetFixturesByDateIntervalAndLeague(DateTime from, DateTime to, string league)
        {
            string key = MethodBase.GetCurrentMethod().Name +
                         from.ToShortDateString() +
                         to.ToShortDateString() + league;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetFixturesByDateIntervalAndLeague(from, to, league);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        public IList<Match> GetFixturesByDateIntervalAndTeam(DateTime from, DateTime to, string team)
        {
            string key = MethodBase.GetCurrentMethod().Name +
                         from.ToShortDateString() +
                         to.ToShortDateString() + team;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetFixturesByDateIntervalAndTeam(from, to, team);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        public IList<Match> GetFixturesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetFixturesByLeagueAndSeason(league, seasonStartYear);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as List<Match>;
        }

        public Match GetHistoricMatchByFixtureMatchID(int fixtureMatchId)
        {
            string key = MethodBase.GetCurrentMethod().Name + fixtureMatchId;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetHistoricMatchByFixtureMatchID(fixtureMatchId);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as Match;
        }

        public IList<Match> GetHistoricMatchesByLeagueAndDateInterval(DateTime from, DateTime to, string league)
        {
            string key = MethodBase.GetCurrentMethod().Name + from + to + league;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetHistoricMatchesByLeagueAndDateInterval(from, to, league);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<Match>;
        }

        public IList<Match> GetHistoricMatchesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetHistoricMatchesByLeagueAndSeason(league, seasonStartYear);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<Match>;
        }

        public IList<Match> GetHistoricMatchesByTeamAndDateInterval(DateTime from, DateTime to, int teamId)
        {
            string key = MethodBase.GetCurrentMethod().Name + from + to + teamId;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetHistoricMatchesByTeamAndDateInterval(from, to, teamId.ToString());
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<Match>;
        }

        public IList<Match> GetHistoricMatchesByTeamsAndDateInterval(DateTime from, DateTime to, int teamId, int team2Id)
        {
            string key = MethodBase.GetCurrentMethod().Name + from + to + teamId;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetHistoricMatchesByTeamsAndDateInterval(from, to, teamId.ToString(), team2Id.ToString());
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<Match>;
        }

        public IList<TeamLeagueStanding> GetLeagueStandingsBySeason(string league, int seasonStartYear)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetLeagueStandingsBySeason(league, seasonStartYear);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<TeamLeagueStanding>;
        }

        public Player GetPlayerById(int id)
        {
            string key = MethodBase.GetCurrentMethod().Name + id;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetPlayerById(id);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as Player;
        }

        public Team GetTeam(string teamName)
        {
            string key = MethodBase.GetCurrentMethod().Name + teamName;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetTeam(teamName);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as Team;
        }

        public IList<Topscorer> GetTopScorersByLeagueAndSeason(string league, int seasonStartYear)
        {
            string key = MethodBase.GetCurrentMethod().Name + league + seasonStartYear;
            if (HttpContext.Current.Cache[key] == null)
            {
                var info = requester.GetTopScorersByLeagueAndSeason(league, seasonStartYear);
                AddToCache(key, info, MEDIUM_TIME_INTERVAL);
            }

            return HttpContext.Current.Cache[key] as IList<Topscorer>;
        }

        private void AddToCache(string key, object data, int seconds)
        {
            System.Web.HttpContext.Current.Cache.Add(
                key: key,
                value: data,
                dependencies: null,
                absoluteExpiration: Cache.NoAbsoluteExpiration,
                slidingExpiration: new TimeSpan(0, 0, seconds),
                priority: CacheItemPriority.Normal,
                onRemoveCallback: null);
        }
    }
}
