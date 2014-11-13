namespace CornerFlag.Data.Models.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Competition : NamedDatabaseEntry
    {
        public Competition()
        {
            this.Seasons = new HashSet<Season>();
        }

        public Country Country { get; set; }

        public virtual ICollection<Season> Seasons { get; set; }

        public ICollection<Standing> GetLeagueStandings()
        {
            var latestSeason = this.Seasons.OrderByDescending(s => s.StartYear).First();
            var standings = new List<Standing>();
            foreach (var club in latestSeason.ParticipatingClubs)
            {
                // Get games for the current club from current season
                var allGamesThisSeason = club.Games.Where(g => g.Season == latestSeason);
                var homeGames = allGamesThisSeason.Where(g => g.HomeClub == club);
                var awayGames = allGamesThisSeason.Where(g => g.AwayClub == club);

                // Generate a club standing
                var standing = new Standing();
                AddHomeGamesResultToStanding(homeGames, standing);
                AddAwayGamesResultToStanding(awayGames, standing);
                standing.GoalDifference = standing.GoalsFor - standing.GoalsAgainst;
                standing.Points = (standing.Won * 3) + standing.Drawn;

                standings.Add(standing);
            }

            return standings;
        }

        private void AddAwayGamesResultToStanding(IEnumerable<Match> awayGames, Standing standing)
        {
            foreach (var game in awayGames)
            {
                standing.GoalsFor += game.HomeGoalsScored;
                standing.GoalsAgainst += game.AwayGoalsScored;
                var result = game.GetResult();
                switch (result)
                {
                    case Result.HomeTeamVictory:
                        standing.Lost++;
                        break;
                    case Result.AwayTeamVictory:
                        standing.Won++;
                        break;
                    case Result.Draw:
                        standing.Drawn++;
                        break;
                    default:
                        break;
                }
            }
        }
 
        private void AddHomeGamesResultToStanding(IEnumerable<Match> homeGames, Standing standing)
        {
            foreach (var game in homeGames)
            {
                standing.GoalsFor += game.HomeGoalsScored;
                standing.GoalsAgainst += game.AwayGoalsScored;
                var result = game.GetResult();
                switch (result)
                {
                    case Result.HomeTeamVictory:
                        standing.Won++;
                        break;
                    case Result.AwayTeamVictory:
                        standing.Lost++;
                        break;
                    case Result.Draw:
                        standing.Drawn++;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
