using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLSoccerCOM;

namespace CornerFlag.SoccerData
{
    public static class MockedSoccerData
    {
        private static Random rndm = new Random();
        private static string[] leagues = new string[]
        {
            "English Premier League",
            "Serie A",
            "La Liga",
            "Mexican Primera League"
        };

        public static IList<Match> MatchListRandom()
        {
            IList<Match> matches = new List<Match>();
            for (int i = 0; i < 10; i++)
            {
                var newMatch = new Match
                {
                    AwayTeam = "Aberdeen",
                    HomeTeam = "Brooklyn",
                    HomeGoals = rndm.Next(0, 5),
                    AwayGoals = rndm.Next(0, 5),
                    Date = DateTime.Now.AddSeconds(i),
                    FixtureMatch_Id = i + 1,
                    Id = i + 1,
                    League = GetRandomLeague()
                };
                matches.Add(newMatch);
            }

            return matches;
        }

        public static IList<TeamLeagueStanding> LeagueStandingRandom()
        {
            IList<TeamLeagueStanding> leagueStandings = new List<TeamLeagueStanding>();
            for (int i = 0; i < 20; i++)
            {
                var newStanding = new TeamLeagueStanding
                {
                    Team = "Team" + i + 1,
                    Team_Id = i + 1,
                    Played = rndm.Next(0, 31),
                    Won = rndm.Next(0, 15),
                    Lost = rndm.Next(0, 15),
                    Draw = rndm.Next(0, 15),
                    Goals_For = rndm.Next(0, 30),
                    Goals_Against = rndm.Next(0, 30),
                    Goal_Difference = rndm.Next(-30, 31),
                    Points = rndm.Next(0, 55)                    
                };
                leagueStandings.Add(newStanding);
            }

            return leagueStandings;
        }

        private static string GetRandomLeague()
        {
            var index = rndm.Next(0, leagues.Length);
            return leagues[index];
        }
    }
}
